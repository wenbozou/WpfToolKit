using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfToolKit.UI.Controls
{
    public class ModernWindow : Window
    {
        #region 依赖属性
        public static readonly DependencyProperty TitleAreaTemplateProperty = DependencyProperty.Register("TitleAreaTemplate", typeof(DataTemplate), typeof(ModernWindow), new PropertyMetadata(null));
        public DataTemplate TitleAreaTemplate
        {
            get { return (DataTemplate)GetValue(TitleAreaTemplateProperty); }
            set { SetValue(TitleAreaTemplateProperty, value); }
        }

        public static readonly DependencyProperty TitleAreaHeightProperty = DependencyProperty.Register("TitleAreaHeight", typeof(int), typeof(ModernWindow), new PropertyMetadata(0));
        public int TitleAreaHeight
        {
            get { return (int)GetValue(TitleAreaHeightProperty); }
            set { SetValue(TitleAreaHeightProperty, value); }
        }
        #endregion

        #region 鼠标拖动窗口事件处理方法
        protected virtual void ModernWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Source is ModernWindow && e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(e.Source as ModernWindow);
                if (pt.Y >= TitleAreaHeight)
                {
                    return;
                }

                this.DragMove();
            }
        }
        #endregion
    }
}
