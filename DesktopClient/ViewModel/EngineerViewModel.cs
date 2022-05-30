using DesktopClient.Infrastructure.Interfaces;
using DesktopClient.Views;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Server.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DesktopClient.ViewModel
{
    public class EngineerViewModel : BaseViewModel
    {
        public EngineerViewModel(IDialogService dialogService, IDataService dataService)
        {
            InitCommands();

            _dataService = dataService;
            _dialogService = dialogService;

            Details = _dataService.GetDetails();
            Services = _dataService.GetServices();
            Repairs = _dataService.GetRepairs();
        }

        private void InitCommands()
        {
            AddDetail = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.DetailAdd = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.det = new Detail();
            }, nameof(AddDetail));
            EditDetail = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.DetailEdit = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.det = SelectDetail;
            }, nameof(EditDetail));
            DeleteDetail = MakeCommand(async () =>
            {
                if (SelectDetail != null)
                {
                    MessageDialogResult result = await((MetroWindow)App.Current.MainWindow).ShowMessageAsync("Вы уверены?", "Предупреждение",
                    MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings
                    {
                        AffirmativeButtonText = "Ок",
                        NegativeButtonText = "Отмена"
                    });
                    if (result == MessageDialogResult.Affirmative)
                    {
                        _dataService.DeleteDetail(SelectDetail);
                        Details = _dataService.GetDetails();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите деталь");
                }
            }, nameof(DeleteDetail));

            AddService = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.ServiceAdd = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.ser = new Service();
            }, nameof(AddService));
            EditService = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.ServiceEdit = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.ser = SelectService;
            }, nameof(EditService));
            DeleteService = MakeCommand(async () =>
            {
                if (SelectService != null)
                {
                    MessageDialogResult result = await ((MetroWindow)App.Current.MainWindow).ShowMessageAsync("Вы уверены?", "Предупреждение",
                    MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings
                    {
                        AffirmativeButtonText = "Ок",
                        NegativeButtonText = "Отмена"
                    });
                    if (result == MessageDialogResult.Affirmative)
                    {
                        _dataService.DeleteService(SelectService);
                        Services = _dataService.GetServices();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите услугу");
                }
            }, nameof(DeleteService));

            DoRepair = MakeCommand(async () =>
            {
                if (SelectRepair != null)
                {
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.RepairDo = true;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Details = _dataService.GetDetails();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Services = _dataService.GetServices();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.rep = SelectRepair;
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Выберите имущество");
            }, nameof(DoRepair));
        }

        #region Fields

        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        #endregion

        #region Properties

        public ObservableCollection<Detail> Details
        {
            get => Get<ObservableCollection<Detail>>();
            set => Set(value);
        }

        public Detail SelectDetail
        {
            get => Get<Detail>();
            set => Set(value);
        }

        public ObservableCollection<Service> Services
        {
            get => Get<ObservableCollection<Service>>();
            set => Set(value);
        }

        public Service SelectService
        {
            get => Get<Service>();
            set => Set(value);
        }

        public ObservableCollection<Repair> Repairs
        {
            get => Get<ObservableCollection<Repair>>();
            set => Set(value);
        }

        public Repair SelectRepair
        {
            get => Get<Repair>();
            set => Set(value);
        }

        #endregion

        #region Commands

        public ICommand AddDetail { get; set; }
        public ICommand EditDetail { get; set; }
        public ICommand DeleteDetail { get; set; }
        public ICommand AddService { get; set; }
        public ICommand EditService { get; set; }
        public ICommand DeleteService { get; set; }
        public ICommand DoRepair { get; set; }

        #endregion
    }
}
