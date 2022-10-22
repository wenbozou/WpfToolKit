using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.Foundation.Interface
{
    public interface ILog
    {
        bool Init(string fullPath);
        bool Init(string dirPath, string fileName);
        void WriteLog(string format, string arg);
        void WriteExceptionLog(string format, Exception ex);
    }
}
