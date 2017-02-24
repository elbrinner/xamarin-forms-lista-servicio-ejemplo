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
    public class SerieViewModel : BaseViewModel
    {

        private readonly MovieFacade movieFacade;

        private ResultResponse listCine , listBestRatedMovies, listDiscoverMovies , listComingSoonMovies ;
        private Result selectedCine , selectedBestRatedMovies, selectedDiscoverMovies , selectedComingSoonMovies;
        private Result banner1;
        private Result banner2;
        private Result banner3;
        private Result banner4;
        private Command<Result> navMovieSelectedItemCommand;
        public ICommand NavMovieSelectedItemCommand
        {
            get { return navMovieSelectedItemCommand = navMovieSelectedItemCommand ?? new Command<Result>(DoMovieSelectedItemHander); }
        }

        private void DoMovieSelectedItemHander(Result selected)
        {
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

        public Result SelectedCine
        {
            get
            {
                return this.selectedCine;
            }

            set
            {
                this.selectedCine = value;
                this.OnPropertyChanged("SelectedCine");
                this.NavMovieSelectedItemCommand.Execute(value);
            }
        }

        public Result SelectedBestRatedMovies
        {
            get
            {
                return this.selectedBestRatedMovies;
            }

            set
            {
                this.selectedBestRatedMovies = value;
                this.OnPropertyChanged("SelectedBestRatedMovies");
                this.NavMovieSelectedItemCommand.Execute(value);
            }
        }

        public Result SelectedDiscoverMovies
        {
            get
            {
                return this.selectedDiscoverMovies;
            }

            set
            {
                this.selectedDiscoverMovies = value;
                this.OnPropertyChanged("SelectedDiscoverMovies");
                this.NavMovieSelectedItemCommand.Execute(value);
            }
        }

        public Result SelectedComingSoonMovies
        {
            get
            {
                return this.selectedComingSoonMovies;
            }

            set
            {
                this.selectedComingSoonMovies = value;
                this.OnPropertyChanged("SelectedComingSoonMovies");
                this.NavMovieSelectedItemCommand.Execute(value);
            }
        }

        public Result Banner1
        {
            get
            {
                return this.banner1;
            }

            set
            {
                this.banner1 = value;
                this.OnPropertyChanged("Banner1");
            }
        }

        public Result Banner2
        {
            get
            {
                return this.banner2;
            }

            set
            {
                this.banner2 = value;
                this.OnPropertyChanged("Banner2");
            }
        }

        public Result Banner3
        {
            get
            {
                return this.banner3;
            }

            set
            {
                this.banner3 = value;
                this.OnPropertyChanged("Banner3");
            }
        }

        public Result Banner4
        {
            get
            {
                return this.banner4;
            }

            set
            {
                this.banner4 = value;
                this.OnPropertyChanged("Banner4");
            }
        }
        public ResultResponse ListCine
        {
            get
            {
                return this.listCine;
            }

            set
            {
                this.listCine = value;
                this.OnPropertyChanged("ListCine");
            }
        }

        public ResultResponse ListBestRatedMovies
        {
            get
            {
                return this.listBestRatedMovies;
            }

            set
            {
                this.listBestRatedMovies = value;
                this.OnPropertyChanged("ListBestRatedMovies");
            }
        }

        public ResultResponse ListDiscoverMovies
        {
            get
            {
                return this.listDiscoverMovies;
            }

            set
            {
                this.listDiscoverMovies = value;
                this.OnPropertyChanged("ListDiscoverMovies");
            }
        }

        public ResultResponse ListComingSoonMovies
        {
            get
            {
                return this.listComingSoonMovies;
            }

            set
            {
                this.listComingSoonMovies = value;
                this.OnPropertyChanged("ListComingSoonMovies");
            }
        }
        #endregion
        public SerieViewModel()
        {
            this.Title = "Series";
            this.movieFacade = new MovieFacade();
        }


        public SerieViewModel(MasterDetailPage currentMasterPage)
        {
            this.CurrentMasterPage = currentMasterPage;
            this.Title = "Series";
            this.movieFacade = new MovieFacade();
        }

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            this.GetSerieDiscover();
            this.GetSeriePopular();
            this.GetSerieToday();
            this.GetSerieTopRated();
        }

        /// <summary>
        /// Peliculas en el cine
        /// </summary>
        public async void GetSerieDiscover()
        {
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetSerieDiscover();
                this.Banner1 = response.Results.Where(p=> p.Backdrop_path != Forms.Contants.Config.BannerGeneric).FirstOrDefault();
                this.IsBusy = false;

                this.ListCine = response;

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

        /// <summary>
        /// Peliculas mejores valoradas
        /// </summary>
        public async void GetSeriePopular()
        {

            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetSeriePopular();
                this.Banner2 = response.Results.Where(p => p.Backdrop_path != Forms.Contants.Config.BannerGeneric).FirstOrDefault();
                this.IsBusy = false;

                this.ListBestRatedMovies = response;

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

        /// <summary>
        /// Próximas peliculas
        /// </summary>
        public async void GetSerieToday()
        {
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetSerieToday();
                this.Banner3 = response.Results.Where(p => p.Backdrop_path != Forms.Contants.Config.BannerGeneric).FirstOrDefault();
                this.IsBusy = false;
                this.ListComingSoonMovies = response;

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


        /// <summary>
        /// Próximas peliculas
        /// </summary>
        public async void GetSerieTopRated()
        {
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetSerieTopRated();
                this.Banner4 = response.Results.Where(p => p.Backdrop_path != Forms.Contants.Config.BannerGeneric).FirstOrDefault();
                this.IsBusy = false;
                this.ListDiscoverMovies = response;
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
