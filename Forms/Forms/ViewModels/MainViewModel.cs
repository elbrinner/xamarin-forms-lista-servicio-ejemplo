using Forms.Dtos;
using Forms.Models;
using Forms.Services.Facade;
using Forms.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Forms.ViewModels
{
    public class MainViewModel : BaseViewModel 
    {
        private ResultResponse listData;
        private Result selectedItem;
        private readonly MovieFacade movieFacade;

        private ICommand basicCommand;

        public MainViewModel()
        {
            this.Title = "Listado de las peliculas";
            this.movieFacade = new MovieFacade();
        }

        public MainViewModel(MasterDetailPage currentMasterPage)
        {
            this.CurrentMasterPage = currentMasterPage;
            this.Title = "Listado de las peliculas";
            this.movieFacade = new MovieFacade();
        }

        public ICommand BasicCommand
        {
            get { return basicCommand = basicCommand ?? new Command<Result>(BasicCommandExecute); }
        }

       

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            this.ListMovie();
        }

        protected override void CurrentPageOnDisappearing(object sender, EventArgs eventArgs) {
            
        }
        public Result SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if (value != null)
                {
                    selectedItem = value;
                    BasicCommandExecute(value);
                    //hacer uso de menseger para avisar al padre?
                }
               
                OnPropertyChanged();

            }
        }

        public void BasicCommandExecute(Result selected)
        {

            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                //this.CurrentMasterPage.Detail = new DetailView(selected, this.CurrentMasterPage);
                Services.Navigation.NavigationService.Instance.NavigateToMaster<DetailViewModel>(selected,this.CurrentMasterPage);
            }
            else
            {
                Services.Navigation.NavigationService.Instance.NavigateTo<DetailViewModel>(selected);
            }
            //App.Current.MainPage = new DetailView(selected); //quito el botón

            // 
        }

        public ResultResponse ListData
        {
            get
            {
                return this.listData;
            }

            set
            {
                this.listData = value;
                this.OnPropertyChanged();
            }
        }

        public async void ListMovie()
        {
            
            if (this.ListData != null)
            {
                return;
            }
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.MovieLast();
                this.IsBusy = false;
                this.ListData = response;

            }
            catch (Exception ex)
            {
                await CurrentPage.DisplayAlert("Error", ex.Message, "OK");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally{
                this.IsBusy = false;
            }          
        }
    }
}
