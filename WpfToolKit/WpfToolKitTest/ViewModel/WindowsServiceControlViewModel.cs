using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKit.Command;
using WpfToolKit.Core;
using WpfToolKit.Helper;

namespace WpfToolKitTest.ViewModel
{
    public class WindowsServiceControlViewModel: PropertyChangedBase
    {
        #region 字段
        string serviceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\MyWindowsService\bin\Debug\MyWindowsService.exe");;
        string serviceName = "MyService";
        #endregion

        #region 属性

        #endregion

        #region 构造函数
        public WindowsServiceControlViewModel()
        {
        }
        #endregion

        #region 命令
        public RelayCommand InstallServiceCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    Task.Run(() =>
                    {
                        //ShowMessage("开始安装服务...");
                        if (WindowsServiceHelper.IsServiceExisted(serviceName))
                        {
                            WindowsServiceHelper.UninstallService(serviceFilePath);
                        }
                        WindowsServiceHelper.InstallService(serviceFilePath);
                    });
                });
            }
        }
        public RelayCommand StartServiceCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    Task.Run(() =>
                    {
                        //ShowMessage("服务正在启动...");
                        if (WindowsServiceHelper.IsServiceExisted(serviceName))
                        {
                            WindowsServiceHelper.ServiceStart(serviceName);
                            //ShowMessage("服务已启动");
                        }

                    });
                });
            }
        }
        public RelayCommand StopServiceCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    Task.Run(() =>
                    {
                        //ShowMessage("服务正在停止...");
                        if (WindowsServiceHelper.IsServiceExisted(serviceName))
                        {
                            WindowsServiceHelper.ServiceStop(serviceName);
                            //ShowMessage("服务已停止");
                        }
                    });
                });
            }
        }
        public RelayCommand UninstallServiceCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    Task.Run(() =>
                    {
                        //ShowMessage("开始卸载服务...");
                        if (WindowsServiceHelper.IsServiceExisted(serviceName))
                        {
                            WindowsServiceHelper.ServiceStop(serviceName);
                        }
                        WindowsServiceHelper.UninstallService(serviceFilePath);
                    });
                });
            }
        }
        #endregion


    }
}
