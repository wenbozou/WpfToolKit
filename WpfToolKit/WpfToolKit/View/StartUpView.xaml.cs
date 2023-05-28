using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfToolKit.ViewModel;

namespace WpfToolKit.View
{
    /// <summary>
    /// StartUpView.xaml 的交互逻辑
    /// </summary>
    public partial class StartUpView : Window
    {

        private AutoResetEvent _AutoReset = new AutoResetEvent(false);
        public AutoResetEvent AutoReset
        {
            get { return _AutoReset; }
        }

        public StartUpView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window mainWin = new MainWindowView();

            _ = Task.Run(() => {
                AutoReset.WaitOne();
                Thread.Sleep(2000);
                
                DispatcherHelper.UIDispatcher.Invoke(()=> {
                //Dispatcher.Invoke(() => {
                    App.Current.MainWindow = mainWin;
                    this.Close();
                    mainWin.Show();
                });
            });

        }
    }
}
