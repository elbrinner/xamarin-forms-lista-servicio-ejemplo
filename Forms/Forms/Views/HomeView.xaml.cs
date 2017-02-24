using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class HomeView : MasterDetailPage
    {
        public HomeView()
        {
            InitializeComponent();
            var vm = new HomeViewModel();
            this.BindingContext = vm;
            vm.Initialize(this);
            Detail = new IndexView(vm.CurrentMasterPage);
          
        }
    }
}
