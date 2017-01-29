using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Forms.Dtos;

namespace Forms.Views
{
    public partial class DetailView : ContentPage
    {        
        public DetailView(ResultDto item)
        {
            InitializeComponent();
            this.BindingContext = new DetailViewModel(item);
            this.Title = item.title;
        }
    }
}
