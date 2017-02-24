using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Services.Navigation
{
    using System;
    using System.Collections.Generic;
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public class NavigationService
    {
        private static NavigationService instance;
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(MainViewModel),  typeof(MainView) },
            { typeof(HomeViewModel),  typeof(HomeView) },
            { typeof(IndexViewModel),  typeof(IndexView) },
            { typeof(MovieViewModel),  typeof(MovieView) },
            { typeof(DetailViewModel), typeof(DetailView) }
        };

        public static NavigationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NavigationService();
                }

                return instance;
            }
        }

        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page; // Agregue el parametro. Revisar

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public void NavigateToMaster<TDestinationViewModel>(object navigationContext = null, MasterDetailPage master=null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext, master) as Page; 

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public void NavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
