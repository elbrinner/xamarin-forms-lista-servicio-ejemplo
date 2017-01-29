using Forms.Dtos;
using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class MainView : ContentPage 
    {
        public Boolean IsBusy { get; set; }
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = (MainViewModel)BindingContext;

            vm.LoadServiceInit();
         
        }

        public void ListView_ItemDetail(object sender, ItemTappedEventArgs e)
        {
            ResultDto selected = e.Item as ResultDto;

            Navigation.PushAsync(new DetailView(selected));
        }
    }
}
