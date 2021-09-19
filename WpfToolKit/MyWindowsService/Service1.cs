using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWindowsService
{
    public partial class Service1 : ServiceBase
    {
        #region
        Timer timer1 = new Timer();
        #endregion
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1.Interval = 1000;
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() => {
                File.AppendAllText(@"F:\hello.txt", DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss:fff") +
                    Environment.NewLine);
            });
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
        }
    }
}
