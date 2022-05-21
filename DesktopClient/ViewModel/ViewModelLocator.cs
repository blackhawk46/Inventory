﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using DesktopClient.Infrastructure.Services;
using DesktopClient.Infrastructure.Interfaces;
using System;
using GalaSoft.MvvmLight.Views;

namespace DesktopClient.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ChiefViewModel>();

            SetupNavigation();
        }

        public MainViewModel MainView => ServiceLocator.Current.GetInstance<MainViewModel>();
        public ChiefViewModel ChiefView => ServiceLocator.Current.GetInstance<ChiefViewModel>();

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("ChiefView", new Uri("../Views/ChiefView.xaml", UriKind.Relative));
            navigationService.Configure("EngineerView", new Uri("../Views/EngineerView.xaml", UriKind.Relative));
            navigationService.Configure("EmployeeView", new Uri("../Views/EmployeeView.xaml", UriKind.Relative));
            navigationService.Configure("AddEmp", new Uri("../Views/ChiefMenu/EmployeeAdd.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
