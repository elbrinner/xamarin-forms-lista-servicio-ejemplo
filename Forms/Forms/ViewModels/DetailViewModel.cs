using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms.Dtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;
using Forms.Services.Facade;

namespace Forms.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private ResultDto item;
        private string img;
        private DetailResponseDto detailItem;
        private readonly MovieFacade movieFacade;

        public DetailResponseDto DetailItem
        {
            get
            {
                return this.detailItem;
            }

            set
            {
                this.detailItem = value;
                this.OnPropertyChanged();
            }
        }

        public string Img
        {
            get
            {
                return this.img;
            }

            set
            {
                this.img = value;
                this.OnPropertyChanged();
            }
        }
        public ResultDto Item
        {
            get
            {
                return this.item;
            }

            set
            {
                this.item = value;
                this.OnPropertyChanged();
            }
        }

        public DetailViewModel(ResultDto item)
        {
            this.Img = Contants.Config.imgBig + item.poster_path;
            this.Item = item;
            this.movieFacade = new MovieFacade();
        }

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            this.IsBusy = true;
            try
            {
                this.IsBusy = true;
                var response = await this.movieFacade.DetailMovie(this.Item.id.ToString());
                 this.DetailItem = response;
               
                this.IsBusy = false;

            }
            catch (Exception ex)
            {
                await CurrentPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                this.IsBusy = false;

            }
        }

      
    }
}
