using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfToolKit.View;

namespace WpfToolKit
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        #region 字段
        private AutoResetEvent autoReset = new AutoResetEvent(false);
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            #region 初始化 DispatcherHelper
            DispatcherHelper.Initialize();
            #endregion

            #region 显示启动页
            StartUpView startupWin = new StartUpView();
            this.MainWindow = startupWin;
            startupWin.Show();
            #endregion

            #region 初始化工作
            #endregion

            #region 自动关闭启动页，并显示主窗口
            startupWin.AutoReset.Set();
            #endregion
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
        }
    }
}
