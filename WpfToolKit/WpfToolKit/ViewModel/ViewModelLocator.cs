/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfToolKit"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using WpfToolKit.Core.Service;
using WpfToolKit.ViewModel.MoreTool;

namespace WpfToolKit.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<StartUpViewModel>();
            SimpleIoc.Default.Register<ToolPanelViewModel>();

            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(()=> navigationService);
        }

        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure("toolPanel", new System.Uri("/WpfToolKit;component/View/MoreTool/ToolPanelView.xaml", UriKind.Relative));

            return navigationService;
        }

        public MainWindowViewModel MainVm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        public StartUpViewModel StartupVm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartUpViewModel>();
            }
        }

        public ToolPanelViewModel ToolPanelVm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ToolPanelViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}