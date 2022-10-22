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
using WpfToolKitTest.ViewModel.ServiceTest;

namespace WpfToolKitTest.View.ServiceTest
{
    /// <summary>
    /// WindowsServiceControlView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowsServiceControlView : Page
    {
        private WindowsServiceControlViewModel _ViewModel = null;

        public WindowsServiceControlView()
        {
            InitializeComponent();
            _ViewModel = new WindowsServiceControlViewModel();
            this.DataContext = _ViewModel;
        }
    }
}
