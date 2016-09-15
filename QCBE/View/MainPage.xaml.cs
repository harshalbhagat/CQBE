using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using QCBE.ViewModel;

namespace QCBE
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MySplitView_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }
    }
}
