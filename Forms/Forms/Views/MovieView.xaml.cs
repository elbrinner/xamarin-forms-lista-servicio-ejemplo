using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Forms.Views
{
    public partial class MovieView : TabbedPage
    {
        public MovieView()
        {
            InitializeComponent();
            var vm = new MovieViewModel();
            this.BindingContext = vm;
            vm.Initialize(this);
        }

        public MovieView(MasterDetailPage currentMasterPage)
        {
            InitializeComponent();
            var vm = new MovieViewModel(currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(this);
        }
    }
}
