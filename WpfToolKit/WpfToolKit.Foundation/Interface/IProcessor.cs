using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.Foundation.Interface
{
    public interface IProcessor
    {
        void Process();

        void OnStop();

        void OnPause();
    }
}
