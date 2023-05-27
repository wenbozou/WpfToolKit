using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.ViewModels
{
    public class MainWindowViewModel
    {

        #region 命令
        public RelayCommand<object> MaxNormalWindowCommand => new RelayCommand<object>(MaxNormalWindowCommandImpl);
        private void MaxNormalWindowCommandImpl(object param)
        {
            if (App.Current.MainWindow.WindowState != System.Windows.WindowState.Maximized)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }

        }
        public RelayCommand<object> CloseWindowCommand => new RelayCommand<object>(CloseWindowCommandImpl);
        private void CloseWindowCommandImpl(object param)
        {
            App.Current.MainWindow.Close();
        }
        #endregion
    }
}
