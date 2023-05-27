using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfToolKit.CtrlLib.Controls
{
    public class ModernWindow: Window
    {
        #region 字段

        #endregion

        #region 依赖属性
        public static readonly DependencyProperty TitleAreaTemplateProperty = DependencyProperty.Register("TitleAreaTemplate", typeof(DataTemplate), typeof(ModernWindow), new PropertyMetadata(null));
        public DataTemplate TitleAreaTemplate
        {
            get { return (DataTemplate)GetValue(TitleAreaTemplateProperty); }
            set { SetValue(TitleAreaTemplateProperty, value); }
        }

        public static readonly DependencyProperty TitleAreaHeightProperty = DependencyProperty.Register("TitleAreaHeight", typeof(int), typeof(ModernWindow), new PropertyMetadata(58));
        public int TitleAreaHeight
        {
            get { return (int)GetValue(TitleAreaHeightProperty); }
            set { SetValue(TitleAreaHeightProperty, value); }
        }
        #endregion
    }
}
