using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKitTest.Models.MoreTools;

namespace WpfToolKitTest.ViewModel.MoreTools
{
    public class MoreToolsViewModel: ViewModelBase
    {
        #region 属性
        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<CbbData> _CbbDatas = new ObservableCollection<CbbData>();
        public ObservableCollection<CbbData> CbbDatas
        {
            get { return _CbbDatas; }
            set
            {
                _CbbDatas = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public MoreToolsViewModel()
        {
            CbbData cbbData1 = new CbbData();
            cbbData1.ID = "";
            cbbData1.Name = "请选择";
            _CbbDatas.Add(cbbData1);
            for (int i = 0; i < 20; i++)
            {
                CbbData cbbData = new CbbData();
                cbbData.ID = (i + 1).ToString();
                cbbData.Name = "test" + (i + 1).ToString();
                _CbbDatas.Add(cbbData);
            }

            DispatcherHelper.Initialize();
        }


        #region UI 绑定的命令
        public RelayCommand AddItemCommand => new RelayCommand(AddItemCommandImpl);

        #endregion

        #region
        private void AddItemCommandImpl()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => {
                if (_CbbDatas != null)
                {
                    int nCount = _CbbDatas.Count;
                    CbbData cbbData = new CbbData();
                    cbbData.ID = (nCount).ToString();
                    cbbData.Name = "test" + (nCount).ToString();
                    _CbbDatas.Add(cbbData);
                }
            });

            //string filePath = @"C:\Program Files (x86)\Tenorshare\Tenorshare iCareFone\RegisterAndLog.dll";
            string filePath = @"G:\SourceCode\WpfToolKit\WpfToolKit\WpfToolKitTest\bin\Debug\WpfToolKit1.dll";
            PEInfos(filePath);
        }


        private void PEInfos(string filePath)
        {
            WpfToolKit.Helper.PeInfo peInfo = new WpfToolKit.Helper.PeInfo(filePath);
            var dt = peInfo.GetPETable();
        }
        #endregion
    }
}
