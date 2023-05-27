using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfToolKit.CtrlLib.Controls
{
    public class ModernWindow : Window
    {
        #region 字段
        /// <summary>
        /// 记录鼠标左键按下位置（鼠标拖动）
        /// </summary>
        private Point _pressedPosition;
        /// <summary>
        /// 记录鼠标拖动状态
        /// </summary>
        private bool _isDragMoved = false;
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

        #region 鼠标拖动事件方法
        protected virtual void ModernWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _pressedPosition = e.GetPosition(this);
        }
        protected virtual void ModernWindow_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && _pressedPosition != e.GetPosition(this))
            {
                _isDragMoved = true;
                DragMove();
            }
        }
        protected virtual void ModernWindow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragMoved)
            {
                _isDragMoved = false;
                e.Handled = true;
            }
        }
        #endregion
    }
}
