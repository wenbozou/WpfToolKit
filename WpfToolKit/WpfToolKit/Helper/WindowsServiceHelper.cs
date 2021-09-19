using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.Helper
{
    public class WindowsServiceHelper
    {
        //
        public static bool IsServiceExisted(string serviceName)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController sc in services)
                {
                    if (sc.ServiceName.ToLower() == serviceName.ToLower()) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //ShowMessage(ex.Message);
                return false;
            }
        }

        // 安装服务
        public static void InstallService(string serviceFilePath)
        {
            try
            {
                using (AssemblyInstaller installer = new AssemblyInstaller())
                {
                    installer.UseNewContext = true;
                    installer.Path = serviceFilePath;
                    IDictionary saveState = new Hashtable();
                    installer.Install(saveState);
                    installer.Commit(saveState);
                }
            }
            catch (Exception ex)
            {
                //ShowMessage(ex.Message);
            }
        }

        //卸载服务
        public static void UninstallService(string serviceFilePath)
        {
            try
            {
                using (AssemblyInstaller installer = new AssemblyInstaller())
                {
                    installer.UseNewContext = true;
                    installer.Path = serviceFilePath;
                    installer.Uninstall(null);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //启动服务
        public static void ServiceStart(string serviceName)
        {
            try
            {
                using (ServiceController control = new ServiceController(serviceName))
                {
                    if (control.Status == ServiceControllerStatus.Stopped)
                    {
                        control.Start();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //停止服务
        public static void ServiceStop(string serviceName)
        {
            try
            {
                using (ServiceController control = new ServiceController(serviceName))
                {
                    if (control.Status == ServiceControllerStatus.Running)
                    {
                        control.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
