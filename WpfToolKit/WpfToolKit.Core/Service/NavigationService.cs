using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfToolKit.Core.Service
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        #region 字段
        private readonly Dictionary<string, Uri> _dicPageByKey;
        private readonly List<string> _lstHistoric;
        #endregion

        #region 属性
        private string _currentPageKey;
        public string CurrentPageKey
        {
            get { return _currentPageKey; }
            private set
            {
                Set(() => CurrentPageKey, ref _currentPageKey, value);
            }
        }

        public object Parameter { get; private set; }
        #endregion

        #region Ctors and Methods
        public NavigationService()
        {
            _dicPageByKey = new Dictionary<string, Uri>();
            _lstHistoric = new List<string>();
        }

        public void GoBack()
        {
            int nCount = _lstHistoric.Count;
            if (nCount > 1)
            {
                _lstHistoric.RemoveAt(nCount - 1);
                NavigateTo(_lstHistoric.Last(), "Back");
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_dicPageByKey)
            {
                if (!_dicPageByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = GetChildElementFromName(Application.Current.MainWindow, "MainFrame") as Frame;
                if (null != frame && CurrentPageKey != pageKey)
                {
                    frame.Source = _dicPageByKey[pageKey];
                    Parameter = parameter;
                    if (parameter.ToString().Equals("Next"))
                    {
                        _lstHistoric.Add(pageKey);
                    }
                    CurrentPageKey = pageKey;
                }
            }
        }

        public void Configure(string key, Uri pageUri)
        {
            if (string.IsNullOrWhiteSpace(key) || null == pageUri)
            {
                return;
            }
            lock (_dicPageByKey)
            {
                if (_dicPageByKey.ContainsKey(key))
                {
                    _dicPageByKey[key] = pageUri;
                }
                else
                {
                    _dicPageByKey.Add(key, pageUri);
                }
            }
        }

        private static FrameworkElement GetChildElementFromName(DependencyObject parent, string name)
        {
            FrameworkElement childElement = null;

            var nCount = VisualTreeHelper.GetChildrenCount(parent);
            if (nCount < 1)
            {
                return childElement;
            }

            for (int i = 0; i < nCount; i++)
            {
                FrameworkElement frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (null != frameworkElement)
                {
                    if (name == frameworkElement.Name)
                    {
                        childElement = frameworkElement;
                        break;
                    }

                    frameworkElement = GetChildElementFromName(frameworkElement, name);
                    if (null != frameworkElement)
                    {
                        childElement = frameworkElement;
                        break;
                    }
                }
            }

            return childElement;
        }
        #endregion
    }
}
