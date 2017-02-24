using Forms.Models;
using Forms.Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        private readonly MovieFacade movieFacade;
        private ResultResponse listData;
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
        public ConfigViewModel()
        {

        }
        public ConfigViewModel(MasterDetailPage currentMasterPage)
        {
            CurrentMasterPage = currentMasterPage;
            this.movieFacade = new MovieFacade();
        }

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            this.GetDiscoverMovies();
        }

        /// <summary>
        /// Próximas peliculas
        /// </summary>
        public async void GetDiscoverMovies()
        {
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.GetDiscoverMovies();
                this.IsBusy = false;
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
