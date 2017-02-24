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


        public MainView(MasterDetailPage currentMasterPage)
        {
            InitializeComponent();
            var vm = new MainViewModel(currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(this);
           // this.currentMasterPage = currentMasterPage;
        }

        public MainView()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            this.BindingContext = vm;
            vm.Initialize(this);
        }
    }
}
