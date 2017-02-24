using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class SerieView : TabbedPage
    {
        public SerieView()
        {
            InitializeComponent();
            var vm = new SerieViewModel();
            this.BindingContext = vm;
            vm.Initialize(this);
        }

        public SerieView(MasterDetailPage currentMasterPage)
        {
            InitializeComponent();
            var vm = new SerieViewModel(currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(this);
        }
    }
}
