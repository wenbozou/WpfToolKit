using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfToolKit.CtrlLib.Controls
{
    public class ModernRadioButton : RadioButton
    {
        #region 依赖属性
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ModernRadioButton), new PropertyMetadata(new CornerRadius(0, 0, 0, 0), OnPropertyChangedCallback));
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
    }
}
