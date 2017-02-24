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
using Xamarin.Forms;
using Forms.Models;

namespace Forms.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Result item;
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
        public Result Item
        {
            get
            {
                return this.item;
            }

            set
            {
                this.item = value;
                this.OnPropertyChanged("Item");
            }
        }

        public DetailViewModel(Result item)
        {
            this.Item = item;
            //this.movieFacade = new MovieFacade();
            this.Title = item.Title == null ? item.Name : item.Title;

        }



        public DetailViewModel(Result item, MasterDetailPage currentMasterPage) : this(item)
        {
            this.CurrentMasterPage = currentMasterPage;
            this.Img = Contants.Config.imgBig + item.Poster_path;
            this.movieFacade = new MovieFacade();
            this.Title = item.Title == null ? item.Name : item.Title;
        }


      
    }
}
