using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfToolKitTest.View;
using WpfToolKitTest.View.MoreTools;
using WpfToolKitTest.View.ServiceTest;

namespace WpfToolKitTest.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 字段
        private MainWindow _ActiveView = null;
        private Frame _ActiveFrame = null;
        #endregion

        #region 属性
        #endregion

        #region 构造
        public MainWindowViewModel()
        {
        }
        #endregion

        #region UI 绑定的 Command
        public RelayCommand CloseCommand => new RelayCommand(CloseCommandImpl);
        public RelayCommand ServiceStartTestCommand => new RelayCommand(ServiceStartTestCommandImpl);
        public RelayCommand MoreToolsCommand => new RelayCommand(MoreToolsCommandImpl);
        #endregion

        #region Command 执行的方法
        private void CloseCommandImpl()
        {
            if (_ActiveView != null)
            {
                _ActiveView.Close();
            }
        }
        private void ServiceStartTestCommandImpl()
        {
            if (_ActiveFrame != null && !(_ActiveFrame.Content is WindowsServiceControlView))
            {
                _ActiveFrame.Content = new WindowsServiceControlView();
            }
            //IRegistryService registryService = RegistryService.GetInstance();

            //registryService.AddRegistryKey(RootKey.LOCAL_MACHINE, @"SOFTWARE\Tenorshare", "Test", "12");
        }
        private void MoreToolsCommandImpl()
        {
            if (_ActiveFrame != null && !(_ActiveFrame.Content is MoreToolsView))
            {
                _ActiveFrame.Content = new MoreToolsView();
            }
        }
        #endregion

        public void OnViewLoaded(object view)
        {
            _ActiveView = view as MainWindow;
            if (_ActiveView != null)
            {
                _ActiveFrame = _ActiveView.MainPage;
            }
        }
    }
}
