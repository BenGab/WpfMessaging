using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MvvmBestPractices.Helpers;
using MvvmBestPractices.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmBestPractices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            RegisterServices();
            base.OnStartup(e);
        }

        public MainWindowViewModel MainVM
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainWindowViewModel>(); ;
            }
        }

        public ModalWindowViewModel ModalVm
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ModalWindowViewModel>();
            }
        }

        private void RegisterServices()
        {
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IMessenger>(() =>Messenger.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<ModalWindowViewModel>(true);
        }
    }
}
