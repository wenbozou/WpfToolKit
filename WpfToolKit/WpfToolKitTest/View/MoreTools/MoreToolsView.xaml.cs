using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfToolKitTest.Models.MoreTools;

namespace WpfToolKitTest.View.MoreTools
{
    /// <summary>
    /// MoreToolsView.xaml 的交互逻辑
    /// </summary>
    public partial class MoreToolsView : Page
    {
        public MoreToolsView()
        {
            InitializeComponent();

            List<CbbData> cbbDatas = new List<CbbData>();
            CbbData cbbData1 = new CbbData();
            cbbData1.ID = "";
            cbbData1.Name = "请选择";
            cbbDatas.Add(cbbData1);
            for (int i = 0; i < 20; i++)
            {
                CbbData cbbData = new CbbData();
                cbbData.ID = (i + 1).ToString();
                cbbData.Name = "test" + (i + 1).ToString();
                cbbDatas.Add(cbbData);
            }

            myCbb.ItemsSource = cbbDatas;
        }
    }
}
