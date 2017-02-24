using Forms.Dtos;
using Forms.Models;
using Forms.Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Forms.Views;
using Forms.Services.SpecificPlatform;

namespace Forms.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {

        private readonly MovieFacade movieFacade;

        private ResultResponse listData;
        private Result selectedItem;
        private Result carruselPage1;
        private Command<Result> navMovieSelectedItemCommand;
        public ICommand NavMovieSelectedItemCommand
        {
            get { return navMovieSelectedItemCommand = navMovieSelectedItemCommand ?? new Command<Result>(DoMovieSelectedItemHander); }
        }

        private void DoMovieSelectedItemHander(Result selected)
        {
            //Services.Navigation.NavigationService.Instance.NavigateTo<DetailViewModel>(selected);
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                CurrentMasterPage.Detail = new DetailView(selected);
            }
            else
            {
                Services.Navigation.NavigationService.Instance.NavigateTo<DetailViewModel>(selected);
            }
        }

        #region propiedades

        public Result SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
                this.NavMovieSelectedItemCommand.Execute(value);
            }
        }

        //public Result Banner1
        //{
        //    get
        //    {
        //        return this.banner1;
        //    }

        //    set
        //    {
        //        this.banner1 = value;
        //        this.OnPropertyChanged("Banner1");
        //    }
        //}
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


        #endregion
        public IndexViewModel()
        {
            this.Title = "Peliculas 2";
            this.movieFacade = new MovieFacade();
        }


        public IndexViewModel(MasterDetailPage currentMasterPage)
        {
            this.CurrentMasterPage = currentMasterPage;
            this.Title = "Peliculas 2";
            this.movieFacade = new MovieFacade();
            
            this.ListMovie();
        }

       

        public async void ListMovie()
        {

            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetCine();
                var ListTemp = response.Results.Where(p=> p.Backdrop_path != Contants.Config.BannerGeneric).ToList();
                //this.Banner1 = temp[0];
                this.IsBusy = false;

            //    List<ContentPage> pages = new List<ContentPage>(0);

            //    foreach (Result item  in ListTemp)
            //    {
            //        pages.Add(new ContentPage
            //        {
            //            Content = new StackLayout
            //            {
            //                 HeightRequest=200,
            //                Children = {
            //                    new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand,
            //                             Children = {

            //                            Device.Idiom == TargetIdiom.Desktop  || Device.Idiom == TargetIdiom.Tablet?
            //                                       new Image {
            //                                            VerticalOptions = LayoutOptions.FillAndExpand ,
            //                                            Source = item.PosterBig,
                                                        
            //                                    }
            //                                    :
            //                                        new Image {
            //                                            VerticalOptions = LayoutOptions.FillAndExpand ,
            //                                            Source = item.PhotoBig,

            //                                    }

            //                                }
            //    }
                
            //}
            //            }
            //        });
            //    }

            //    CurrentMasterPage.Detail = new CarouselPage
            //    {
            //      Children = { pages [0],
            //       pages [1],
            //       pages [2],
            //       pages [3],
            //       pages [4] }
            //    };
                this.ListData = response;

            }
            catch (Exception ex)
            {
                await CurrentPage.DisplayAlert("Error", ex.Message, "OK");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
