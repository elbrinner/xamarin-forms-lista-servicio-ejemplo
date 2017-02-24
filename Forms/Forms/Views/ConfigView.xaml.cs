using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class ConfigView : ContentPage
    {
        public ConfigView()
        {
            InitializeComponent();
        }

        public ConfigView(MasterDetailPage currentMasterPage)
        {
            InitializeComponent();
            var vm = new ConfigViewModel(currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(this);
        }

      
    }
}
