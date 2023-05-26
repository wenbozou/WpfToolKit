using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;

namespace WpfToolKit.Helper
{
    public class ListViewSelectionHelper : FrameworkElement
    {
        #region 字段
        private static List<ListViewItem> _selectedItem = new List<ListViewItem>();
        private static Point _startPos = new Point(-1, -1);
        private static Point _lastPos = new Point(-1, -1);
        #endregion

        #region 附加属性
        public static readonly DependencyProperty MultiSelectProperty = DependencyProperty.RegisterAttached("MultiSelect", typeof(bool), typeof(ListViewSelectionHelper), new PropertyMetadata(new PropertyChangedCallback(OnMultiSelectInvalidated)));
        public static readonly DependencyProperty PreviewDragProperty = DependencyProperty.RegisterAttached("PreviewDrag", typeof(bool), typeof(ListViewSelectionHelper));
        protected static readonly DependencyProperty IsDraggingProperty = DependencyProperty.RegisterAttached("isDragging", typeof(bool), typeof(ListViewSelectionHelper));
        protected static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached("Background", typeof(Color), typeof(ListViewSelectionHelper));
        #endregion

        #region 静态方法
        public static bool GetMultiSelect(DependencyObject sender)
        {
            return (bool)sender.GetValue(MultiSelectProperty);
        }

        public static void SetMultiSelect(DependencyObject sender, bool value)
        {
            sender.SetValue(MultiSelectProperty, value);
        }

        public static bool GetPreviewDrag(DependencyObject sender)
        {
            return (bool)sender.GetValue(PreviewDragProperty);
        }

        public static void SetPreviewDrag(DependencyObject sender, bool value)
        {
            sender.SetValue(PreviewDragProperty, value);
        }

        protected static bool GetIsDragging(DependencyObject sender)
        {
            return (bool)sender.GetValue(IsDraggingProperty);
        }

        protected static void SetIsDragging(DependencyObject sender, bool value)
        {
            sender.SetValue(IsDraggingProperty, value);
        }

        protected static Color GetBackground(DependencyObject sender)
        {
            return (Color)sender.GetValue(BackgroundProperty);
        }

        protected static void SetBackground(DependencyObject sender, Color value)
        {
            sender.SetValue(BackgroundProperty, value);
        }
        #endregion

        #region 事件处理
        private static void OnMultiSelectInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)dependencyObject;

            if (!(element is ListView))
            {
                throw new ArgumentException("Element not ListView");
            }

            ListView lvElement = (ListView)element;
            if ((bool)e.NewValue == true)
            {
                SetMultiSelect(element, true);
                if (lvElement.Background is SolidColorBrush)
                {
                    SetBackground(lvElement, (lvElement.Background as SolidColorBrush).Color);
                }
                else
                {
                    SetPreviewDrag(lvElement, false);
                }

                lvElement.SelectionMode = SelectionMode.Extended;
                lvElement.PreviewMouseDown += new MouseButtonEventHandler(lvElement_PreviewMouseDown);
                lvElement.MouseDown += new MouseButtonEventHandler(lvElement_MouseDown);
                lvElement.MouseMove += new MouseEventHandler(lvElement_MouseMove);
                lvElement.MouseUp += new MouseButtonEventHandler(lvElement_MouseUp);
            }
            else
            {
                var adorner = AdornerLayer.GetAdornerLayer(element);
                if (adorner != null)
                {
                    var selectAdorner = adorner.GetAdorners(element).FirstOrDefault(p => p.GetType() == typeof(SelectionAdorner)) as SelectionAdorner;
                    if (selectAdorner != null)
                    {
                        adorner.Remove(selectAdorner);
                    }
                }
                SetMultiSelect(element, false);
                lvElement.PreviewMouseDown -= new MouseButtonEventHandler(lvElement_PreviewMouseDown);
                lvElement.MouseDown -= new MouseButtonEventHandler(lvElement_MouseDown);
                lvElement.MouseMove -= new MouseEventHandler(lvElement_MouseMove);
                lvElement.MouseUp -= new MouseButtonEventHandler(lvElement_MouseUp);
            }
        }
        private static void lvElement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ListView lvSender = sender as ListView;

            //Ignore if click on scroll bar.
            if (e.MouseDevice.DirectlyOver == null)
            {
                return;
            }
            string controlName = e.MouseDevice.DirectlyOver.GetType().Name;

            if (!(controlName == "ScrollChrome") && !(controlName == "Rectangle"))
            {
                if (!(Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
                {
                    #region 右键按下
                    //如果是右键
                    if (Mouse.RightButton == MouseButtonState.Pressed)
                    {
                        #region 从Photos获取ListViewItem(已经注销)
                        foreach (var item in lvSender.SelectedItems)
                        {
                            ListViewItem lstitem = lvSender.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                            if (lstitem == null)
                            {
                                continue;
                            }
                            Point ptBT = Mouse.GetPosition(lstitem);
                            if (ptBT.X >= 0 && ptBT.X < lstitem.ActualWidth && ptBT.Y >= 0 && ptBT.Y < lstitem.ActualHeight)
                            {
                                return;
                            }
                        }
                        #endregion
                        //lvSender.SelectedItems.Clear();
                    }
                    #endregion
                    //清除选择项
                    lvSender.SelectedItems.Clear();
                }
            }
        }

        private static void lvElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                ListView lvSender = sender as ListView;

                double xPos = e.MouseDevice.GetPosition(lvSender).X;
                //System.Diagnostics.Debug.WriteLine(VisualTreeHelper.HitTest(lvSender, e.MouseDevice.GetPosition(lvSender)).VisualHit);
                //bool _dragging = (VisualTreeHelper.HitTest(lvSender, e.MouseDevice.GetPosition(lvSender)).VisualHit is ScrollViewer);
                //Fixed : 05-04-08 Cannot drag if Scrollbar not visible (VisialHit = ScrollChome)
                bool _dragging = true;
                SetIsDragging(lvSender, _dragging);

                if (_dragging)
                {
                    lvSender.CaptureMouse();
                    lvSender.SelectionMode = SelectionMode.Multiple;
                    //lvSender.SelectedItems.Clear();

                    _startPos = e.MouseDevice.GetPosition(lvSender);
                    _lastPos = _startPos;
                    //_selectedItem.Clear();
                }
            }
        }
        private static void lvElement_MouseMove(object sender, MouseEventArgs e)
        {
            ListView lvSender = sender as ListView;

            //添加_lastPos != new Point(-1, -1),即只有先点击鼠标左键才开始计数
            if (GetIsDragging(lvSender) && Mouse.LeftButton == MouseButtonState.Pressed && _lastPos != new Point(-1, -1))
            {
                Point current = e.MouseDevice.GetPosition(lvSender);
                Rect selectRect = new Rect(_startPos, current);
                Rect unselectRect = new Rect(_startPos, _lastPos);

                _lastPos = current;

                //Unselect all visible selected items (by using _lastPos) no matter it's current selected or not.
                VisualTreeHelper.HitTest(lvSender, UnselectHitTestFilterFunc, new HitTestResultCallback(SelectResultCallback), new GeometryHitTestParameters(new RectangleGeometry(unselectRect)));

                //Select all visible items in select region.
                VisualTreeHelper.HitTest(lvSender, SelectHitTestFilterFunc, new HitTestResultCallback(SelectResultCallback), new GeometryHitTestParameters(new RectangleGeometry(selectRect)));

                if (!GetPreviewDrag(lvSender))
                {
                    lvSender.SelectedItems.Clear();
                    foreach (ListViewItem item in _selectedItem)
                    {
                        item.IsSelected = true;
                    }
                    lvSender.Focus();
                }
                else
                {
                    if (_startPos != _lastPos && _lastPos != new Point(-1, -1))
                    {
                        var adorner = AdornerLayer.GetAdornerLayer(lvSender);
                        if (adorner != null)
                        {
                            SelectionAdorner selectAdorner = null;
                            var adorners = adorner.GetAdorners(lvSender);
                            if (adorners != null)
                            {
                                foreach (var item in adorners)
                                {
                                    if (item is SelectionAdorner)
                                    {
                                        selectAdorner = item as SelectionAdorner;
                                        break;
                                    }
                                }
                            }
                            if (selectAdorner == null)
                            {
                                selectAdorner = new SelectionAdorner(lvSender);
                                adorner.Add(selectAdorner);
                            }
                            selectAdorner.SelectionArea = selectRect;
                        }
                    }
                }
            }
        }
        private static void lvElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvSender = sender as ListView;

            Brush brushBK = lvSender.Background;

            if (e.ChangedButton == MouseButton.Left)
            {
                if (GetPreviewDrag(lvSender))
                {
                    var adorner = AdornerLayer.GetAdornerLayer(lvSender);
                    if (adorner != null)
                    {
                        SelectionAdorner selectAdorner = null;
                        var adorners = adorner.GetAdorners(lvSender);
                        if (adorners != null)
                        {
                            foreach (var item in adorners)
                            {
                                if (item is SelectionAdorner)
                                {
                                    selectAdorner = item as SelectionAdorner;
                                    break;
                                }
                            }
                        }
                        if (selectAdorner != null) selectAdorner.SelectionArea = default(Rect);
                    }
                }
                if (GetIsDragging(lvSender))
                {
                    SetIsDragging(lvSender, false);

                    if (GetPreviewDrag(lvSender))
                    {
                        lvSender.SelectedItems.Clear();
                        foreach (ListViewItem item in _selectedItem)
                        {
                            item.IsSelected = true;
                        }
                    }
                    _selectedItem.Clear();

                    lvSender.Focus();
                }
                lvSender.SelectionMode = SelectionMode.Extended;
                _lastPos = new Point(-1, -1);
            }
        }
        #endregion

        #region 回调方法
        public static HitTestResultBehavior SelectResultCallback(HitTestResult result)
        {
            return HitTestResultBehavior.Continue;
        }

        public static HitTestFilterBehavior SelectHitTestFilterFunc(DependencyObject potentialHitTestTarget)
        {
            if (potentialHitTestTarget is ListViewItem)
            {
                ListViewItem item = potentialHitTestTarget as ListViewItem;
                item.IsSelected = true;
                _selectedItem.Add(item);

                return HitTestFilterBehavior.ContinueSkipChildren;
            }

            return HitTestFilterBehavior.Continue;
        }

        public static HitTestFilterBehavior UnselectHitTestFilterFunc(DependencyObject potentialHitTestTarget)
        {
            if (potentialHitTestTarget is ListViewItem)
            {
                ListViewItem item = potentialHitTestTarget as ListViewItem;
                item.IsSelected = false;
                _selectedItem.Remove(item);

                return HitTestFilterBehavior.ContinueSkipChildren;
            }

            return HitTestFilterBehavior.Continue;
        }
        #endregion

    }

    internal sealed class SelectionAdorner : Adorner
    {
        #region 字段
        private Rect _selectionRect;
        #endregion

        #region 属性
        public Rect SelectionArea
        {
            get
            {
                return _selectionRect;
            }
            set
            {
                _selectionRect = value;
                InvalidateVisual();
            }
        }
        #endregion

        #region 构造
        public SelectionAdorner(UIElement parent)
            : base(parent)
        {
            this.IsHitTestVisible = false;

            this.IsEnabledChanged += delegate { this.InvalidateVisual(); };
        }
        #endregion

        #region 重载
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Brush selectionBrush = new SolidColorBrush(SystemColors.HighlightColor);
            selectionBrush.Opacity = 0.3;

            double x = Math.Max(0, SelectionArea.X);
            double y = Math.Max(0, SelectionArea.Y);
            double width = SelectionArea.X > 0 ? SelectionArea.Width : SelectionArea.Width + SelectionArea.X;
            double height = SelectionArea.Y > 0 ? SelectionArea.Height : SelectionArea.Height + SelectionArea.Y;
            drawingContext.DrawRectangle(selectionBrush, new Pen(SystemColors.ActiveBorderBrush, 1.0), new Rect(x, y, width, height));
        }
        #endregion
    }
}
