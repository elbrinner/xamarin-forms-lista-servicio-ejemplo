using Forms.Dtos;
using Forms.Models;
using Forms.Services.SpecificPlatform;
using Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Forms.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        //Botones nuevos
        private ICommand navHomeCommand;
        private ICommand navMovieCommand;
        private ICommand navSerieCommand;
        private ICommand navActorCommand;


        public HomeViewModel()
        {
            this.FillMenu();
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                this.Title = "appDemo";
            }
            
        }
        public ICommand NavHomeCommand
        {
            get { return navHomeCommand = navHomeCommand ?? new Command(DoNavHomeCommandHander); }
        }

        public ICommand NavMovieCommand
        {
            get { return navMovieCommand = navMovieCommand ?? new Command(DoNavMovieCommandHander); }
        }

        public ICommand NavSerieCommand
        {
            get { return navSerieCommand = navSerieCommand ?? new Command(DoNavSerieCommandHander); }
        }

        private void DoNavSerieCommandHander(object obj)
        {
            CurrentMasterPage.Detail = new SerieView(this.CurrentMasterPage);
            this.MenuScreen();
        }

        private void DoNavHomeCommandHander(object obj)
        {
             CurrentMasterPage.Detail =  new IndexView(this.CurrentMasterPage);
             this.MenuScreen();
        }

        private void DoNavMovieCommandHander(object obj)
        {
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                CurrentMasterPage.Detail = new MovieView(this.CurrentMasterPage);
            }
            else
            {
                Services.Navigation.NavigationService.Instance.NavigateTo<MovieViewModel>();
            }
        }



        //Botones
        private ICommand navConfigCommand;

        private List<MenuItem> listMenu;
        private MenuItem selectedMenuItem;

        public MenuItem SelectedMenuItem
        {
            get
            {
                return this.selectedMenuItem;
            }

            set
            {
                this.selectedMenuItem = value;
                this.OnPropertyChanged("SelectedMenuItem");
                value.Command.Execute(null);
            }
        }
        public List<MenuItem> ListMenu
        {
            get
            {
                return this.listMenu;
            }

            set
            {
                this.listMenu = value;
                this.OnPropertyChanged("ListMenu");
            }
        }

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            this.MenuScreen();
        }

        public ICommand NavConfigCommand
        {
            get { return navConfigCommand = navConfigCommand ?? new Command(navConfigCommandHander); }
        }

   

        private void navConfigCommandHander(object element)
        {
            this.MenuScreen();
            CurrentMasterPage.Detail = new ConfigView();

            DependencyService.Get<ITextToSpeech>().Speak("Configuración de la página");

        }
  
        private void MenuScreen()
        {
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                CurrentMasterPage.IsPresented = true;
            }
            else
            {
                CurrentMasterPage.IsPresented = false;
            }
        }

        private void FillMenu()
        {
            var menuAux = new List<MenuItem>();
            menuAux.Add(new MenuItem
            {
                Text = "Página principal",
                 Icon = "home.png", 
                Command = NavHomeCommand
            });
            menuAux.Add(new MenuItem
            {
                Text = "Películas",
                Icon = "video.png",
                Command = NavMovieCommand
            });
            menuAux.Add(new MenuItem
            {
                Text = "Series",
                Icon = "television.png",
                Command = NavSerieCommand
            });
            menuAux.Add(new MenuItem
            {
                Text = "Actores",
                Icon = "oscars.png",
                Command = NavConfigCommand
            });
            menuAux.Add(new MenuItem
            {
                Text = "Ajustes",
                Icon = "settings.png",
                Command = NavConfigCommand
            });


            this.ListMenu = menuAux;
        }


    }
}
