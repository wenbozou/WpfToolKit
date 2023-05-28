using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 属性


        private string _ProductName="WpfToolKit";

        public string ProductName
        {
            get { return _ProductName; }
            set {
                _ProductName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region 命令
        public RelayCommand<object> MinWindowCommand => new RelayCommand<object>(MinWindowCommandImpl);
        private void MinWindowCommandImpl(object param)
        {
            if (App.Current.MainWindow.WindowState != System.Windows.WindowState.Minimized)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
            }
        }

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


        public RelayCommand<object> MoreToolCommand => new RelayCommand<object>(MoreToolCommandImpl);

        private void MoreToolCommandImpl(object param)
        {
            var navigationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<INavigationService>();
            navigationService.NavigateTo("toolPanel");
        }
        #endregion
    }
}
