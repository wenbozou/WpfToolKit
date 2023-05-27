using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfToolKit.CtrlLib.Controls;
using WpfToolKit.ViewModels;

namespace WpfToolKit.Views
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : ModernWindow
    {
        public MainWindowView()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }
    }
}
