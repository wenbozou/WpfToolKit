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
using WpfToolKit.Foundation.Interface;
using WpfToolKit.Foundation.Model;
using WpfToolKit.Services;
using WpfToolKitTest.View;
using WpfToolKitTest.View.MoreTools;
using WpfToolKitTest.ViewModel;

namespace WpfToolKitTest.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _ViewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            _ViewModel = new MainWindowViewModel();
            this.DataContext = _ViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string filePath = @"G:\SourceCode\WpfToolKit\WpfToolKit\WpfToolKitTest\Language\en.xaml";
            //ParseLanguageRC(filePath);            
            this._ViewModel.OnViewLoaded(this);
        }


        private void ParseLanguageRC(string filePath)
        {
            //System.IO.StreamReader sr = new System.IO.StreamReader(filePath, Encoding.UTF8);

            //List<string> lstLine = new List<string>();
            //string line;
            //while ((line = sr.ReadLine()) != null)
            //    lstLine.Add(line);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //this.DragMove();
            }
        }
    }
}
