using CQBE.Business.Units;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCBE
{
    public class BaseViewModel : ViewModelBase
    {

        public BaseViewModel()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            UnitsService= ServiceLocator.Current.GetInstance<IUnitsService>();
            DialogService= ServiceLocator.Current.GetInstance<IDialogService>();
        }

        private bool isLoading;
        public virtual bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                RaisePropertyChanged();
            }
        }

            
            
        public IUnitsService UnitsService { set; get; }
        public IDialogService DialogService { set; get; }


        public INavigationService NavigationService { set; get; }
    }
}
