using CQBE.Models;
using Microsoft.Practices.ServiceLocation;
using QCBE.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QCBE.UserControls
{
    public sealed partial class UnitsControl : UserControl
    {
        public UnitsControl()
        {
            this.InitializeComponent();
        }

        private void trvMenu_SelectedItemChanged(object sender, WinRTXamlToolkit.Controls.RoutedPropertyChangedEventArgs<object> e)
        {
            ServiceLocator.Current.GetInstance<UnitsControlViewModel>().SelectedItemValue = (Unit)e.NewValue;
            var selected = ServiceLocator.Current.GetInstance<UnitsControlViewModel>().SelectedItemValue;
            ServiceLocator.Current.GetInstance<UnitsControlViewModel>().Feet = selected == null ? "" : selected.xNameFt;
            ServiceLocator.Current.GetInstance<UnitsControlViewModel>().Metric = selected == null ? "" : selected.xName;
        }
    }
}
