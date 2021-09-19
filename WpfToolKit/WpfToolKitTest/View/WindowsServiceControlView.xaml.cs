using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfToolKitTest.ViewModel;

namespace WpfToolKitTest.View
{
    /// <summary>
    /// WindowsServiceControlView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowsServiceControlView : Page
    {
        public WindowsServiceControlView()
        {
            InitializeComponent();
            this.DataContext = new WindowsServiceControlViewModel();
        }

        private void InstallService_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void StartService_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void StopService_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void UninstallService_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
