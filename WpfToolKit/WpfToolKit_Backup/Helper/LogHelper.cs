using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKit.Foundation.Interface;

namespace WpfToolKit.Helper
{
    public class LogHelper : ILog
    {
        public bool Init(string fullPath)
        {
            throw new NotImplementedException();
        }

        public bool Init(string dirPath, string fileName)
        {
            throw new NotImplementedException();
        }

        void ILog.WriteExceptionLog(string format, Exception ex)
        {
            throw new NotImplementedException();
        }

        void ILog.WriteLog(string format, string arg)
        {
            throw new NotImplementedException();
        }
    }
}
