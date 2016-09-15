using CQBE.Business.Units;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace QCBE.ViewModel
{
    public class ViewModelLocator
    {
        public const string SecondPageKey = "SecondPage";
        public const string MainPage = "MainPage";
        

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Configure(MainPage, typeof(MainPage));

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<UnitsControlViewModel>();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<IUnitsService, UnitsService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
             "CA1822:MarkMembersAsStatic",
             Justification = "This non-static member is needed for data binding purposes.")]
        public UnitsControlViewModel UnitsControlViewModel => ServiceLocator.Current.GetInstance<UnitsControlViewModel>();
        



    }
}
