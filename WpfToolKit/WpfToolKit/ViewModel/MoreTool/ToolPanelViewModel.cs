using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToolKit.ViewModel.MoreTool
{
    public class ToolPanelViewModel : ViewModelBase
    {
        private string _Introduce = "Hello, My Name is ToolPanel";

        public string Introduce
        {
            get { return _Introduce; }
            set { _Introduce = value; RaisePropertyChanged(); }
        }
    }
}
