using Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Forms.Dtos;
using Forms.Models;

namespace Forms.Views
{
    public partial class DetailView : ContentPage
    {

        public DetailView(Result item)
        {
            InitializeComponent();
            var vm = new DetailViewModel(item);
            this.BindingContext = vm;
            vm.Initialize(this);
        }

        public DetailView(Result item, MasterDetailPage currentMasterPage) : this(item)
        {
            InitializeComponent();
            var vm = new DetailViewModel(item, currentMasterPage);
            this.BindingContext = vm;
            vm.Initialize(currentMasterPage,this);
        }
    }
}
