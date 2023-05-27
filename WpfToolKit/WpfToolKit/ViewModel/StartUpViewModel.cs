using GalaSoft.MvvmLight;

namespace WpfToolKit.ViewModel
{
    public class StartUpViewModel : ViewModelBase
    {
        private string _Introduce = "启动中...";

        public string Introduce
        {
            get { return _Introduce; }
            set { _Introduce =  value; RaisePropertyChanged(); }
        }

    }
}
