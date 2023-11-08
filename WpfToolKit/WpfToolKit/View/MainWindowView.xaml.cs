using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfToolKit.UI.Controls;
using WpfToolKit.ViewModel;

namespace WpfToolKit.View
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : ModernWindow
    {
        public MainWindowView()
        {
            InitializeComponent();

            //this.DataContext = new MainWindowViewModel();
        }
    }
}
