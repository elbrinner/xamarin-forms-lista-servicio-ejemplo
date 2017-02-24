using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class IndexView : ContentPage
    {
        public IndexView()
        {
            InitializeComponent();
            var vm = new IndexViewModel();
            this.BindingContext = vm;
            vm.Initialize(this);
        }

        public IndexView(MasterDetailPage currentMasterPage)
        {
            InitializeComponent();
            var vm = new IndexViewModel(currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(this);
        }
    }
}
