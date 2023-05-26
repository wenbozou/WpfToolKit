using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKit.Foundation.Interface;

namespace WpfToolKit.Services
{
    public class LogService : ILog
    {
        #region 字段
        private static LogService _Instance = null;
        private static object _syncLock = new object();
        #endregion

        #region 构造
        protected LogService()
        {}
        #endregion

        #region public 方法
        public static LogService Instance()
        {
            LogService logInstance = null;
            lock (_syncLock)
            {
                if (null == _Instance)
                {
                    _Instance = new LogService();
                }
                logInstance = _Instance;
            }

            return logInstance;
        }
        #endregion

        #region ILog 接口实现
        public bool Init(string fullPath)
        {
            throw new NotImplementedException();
        }

        public bool Init(string dirPath, string fileName)
        {
            throw new NotImplementedException();
        }

        public void WriteExceptionLog(string format, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string format, string arg)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
