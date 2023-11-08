using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.Foundation.Interface
{
    public interface IProgress
    {
        void OnStart(ProgressStartMsg param);
        void OnProgressing(ProgressMsg param);

        void OnSuccess(ProgressSuccessMsg param);

        void OnFailed(ProgressFailedMsg param);

        void OnEnd(ProgressEndMsg param);
    }

    public class ProgressMsgBase
    { 
    }

    public class ProgressStartMsg : ProgressMsgBase
    { }

    public class ProgressMsg : ProgressMsgBase
    { }

    public class ProgressSuccessMsg : ProgressMsgBase
    { 
    }

    public class ProgressFailedMsg : ProgressMsgBase
    { 
    }

    public class ProgressEndMsg : ProgressMsgBase
    { 
    }

}
