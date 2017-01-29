using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms.Dtos;

namespace Forms.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private ResultDto item;
        private string img;

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
        }
    }
}
