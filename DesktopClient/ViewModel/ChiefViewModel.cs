using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Server.Models;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;

namespace DesktopClient.ViewModel
{
    public class ChiefViewModel : BaseViewModel
    {
        public ChiefViewModel(IDialogService dialogService, IDataService dataService, IFrameNavigationService navigationService)
        {
            InitCommands();

            _dataService = dataService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            Departments = _dataService.GetDepartments();
            Places = _dataService.GetPlaces();
            Statuses = _dataService.GetStatuses();
            Employees = _dataService.GetEmployees();
            Assets = _dataService.GetAssets();
            AssetsType = _dataService.GetAssetsType();
            Transfers = _dataService.GetTransfers();

            //Start();
        }

        private void InitCommands()
        {
            AddDepartment = MakeCommand(async () =>
            {
                string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Новая запись", "Введите наименование отдела",
                new MetroDialogSettings
                {
                    AffirmativeButtonText = "Ок",
                    NegativeButtonText = "Отмена"                    
                });
                if (!string.IsNullOrEmpty(result))
                {
                    _dataService.AddDepartment(new Department() { Name = result });
                    Departments = _dataService.GetDepartments();
                }
            }, nameof(AddDepartment));
            EditDepartment = MakeCommand(async () =>
            {
                if (SelectDepartment != null)
                {
                    string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Редактирование", "Введите наименование отдела",
                                       new MetroDialogSettings
                                       {
                                           AffirmativeButtonText = "Ок",
                                           NegativeButtonText = "Отмена",
                                           DefaultText = SelectDepartment.Name
                                       });
                    if (result != SelectDepartment.Name && result != null)
                    {
                        SelectDepartment.Name = result;
                        _dataService.EditDepartment(SelectDepartment);
                        Departments = _dataService.GetDepartments();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите отдел");
                }
            }, nameof(EditDepartment));
            DeleteDepartment = MakeCommand(async () =>
            {
                if (SelectDepartment != null)
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
                        _dataService.DeleteDepartment(SelectDepartment);
                        Departments = _dataService.GetDepartments();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите отдел");
                }
            }, nameof(DeleteDepartment));

            AddPlace = MakeCommand(async () =>
            {
                string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Новая запись", "Введите наименование местоположения",
                new MetroDialogSettings
                {
                    AffirmativeButtonText = "Ок",
                    NegativeButtonText = "Отмена"
                });
                if (!string.IsNullOrEmpty(result))
                {
                    _dataService.AddPlace(new Place() { Name = result });
                    Places = _dataService.GetPlaces();
                }
            }, nameof(AddPlace));
            EditPlace = MakeCommand(async () =>
            {
                if (SelectPlace != null)
                {
                    string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Редактирование", "Введите наименование местоположения",
                                       new MetroDialogSettings
                                       {
                                           AffirmativeButtonText = "Ок",
                                           NegativeButtonText = "Отмена",
                                           DefaultText = SelectPlace.Name
                                       });
                    if (result != SelectPlace.Name && result != null)
                    {
                        SelectPlace.Name = result;
                        _dataService.EditPlace(SelectPlace);
                        Places = _dataService.GetPlaces();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите местоположение");
                }
            }, nameof(EditPlace));
            DeletePlace = MakeCommand(async () =>
            {
                if (SelectPlace != null)
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
                        _dataService.DeletePlace(SelectPlace);
                        Places = _dataService.GetPlaces();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите отдел");
                }
            }, nameof(DeletePlace));

            AddStatus = MakeCommand(async () =>
            {
                string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Новая запись", "Введите наименование статуса",
                new MetroDialogSettings
                {
                    AffirmativeButtonText = "Ок",
                    NegativeButtonText = "Отмена"
                });
                if (!string.IsNullOrEmpty(result))
                {
                    _dataService.AddStatus(new Status() { Name = result });
                    Statuses = _dataService.GetStatuses();
                }
            }, nameof(AddStatus));
            EditStatus = MakeCommand(async () =>
            {
                if (SelectStatus != null)
                {
                    string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Редактирование", "Введите наименование статуса",
                                       new MetroDialogSettings
                                       {
                                           AffirmativeButtonText = "Ок",
                                           NegativeButtonText = "Отмена",
                                           DefaultText = SelectStatus.Name
                                       });
                    if (result != SelectStatus.Name && result != null)
                    {
                        SelectStatus.Name = result;
                        _dataService.EditStatus(SelectStatus);
                        Statuses = _dataService.GetStatuses();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите статус");
                }
            }, nameof(EditStatus));
            DeleteStatus = MakeCommand(async () =>
            {
                if (SelectStatus != null)
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
                        _dataService.DeleteStatus(SelectStatus);
                        Statuses = _dataService.GetStatuses();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите статус");
                }
            }, nameof(DeleteStatus));

            OpenAddEmployee = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.EmployeeAdd = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Departments = _dataService.GetDepartments();
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.empl = new Employee();
            }, nameof(OpenAddEmployee));

            EditEmployee = MakeCommand(async () =>
            {
                if(SelectEmployee!=null)
                {
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.EmployeeEdit = true;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Departments = _dataService.GetDepartments();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.empl = SelectEmployee;
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите сотрудника");
                }
            }, nameof(EditEmployee));

            DeleteEmployee = MakeCommand(async () =>
            {
                if(SelectEmployee != null)
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
                        _dataService.DeleteEmployee(SelectEmployee);
                        Employees = _dataService.GetEmployees();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите сотрудника");
                }
            }, nameof(DeleteEmployee));

            OpenAddAsset = MakeCommand(() =>
            {
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.AssetAdd = true;
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Places = _dataService.GetPlaces();
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Statuses = _dataService.GetStatuses();
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.AssetTypes = _dataService.GetAssetsType();
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.empls = _dataService.GetEmployees();
                ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.asst = new Asset() { Date = DateTime.Now, DateCreate = DateTime.Now };
            }, nameof(OpenAddAsset));

            EditAsset = MakeCommand(async () =>
            {
                if (SelectAsset != null)
                {
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.AssetEdit = true;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Places = _dataService.GetPlaces();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.Statuses = _dataService.GetStatuses();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.AssetTypes = _dataService.GetAssetsType();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.empls = _dataService.GetEmployees();
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.asst = SelectAsset;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).MainView.placetemp = SelectAsset.Place;
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите имущество");
                }
            }, nameof(EditAsset));

            DeleteAsset = MakeCommand(async () =>
            {
                if (SelectAsset != null)
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
                        _dataService.DeleteAsset(SelectAsset);
                        Assets = _dataService.GetAssets();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите имущество");
                }
            }, nameof(DeleteAsset));

            AddAssetType = MakeCommand(async () =>
            {
                string result = await((MetroWindow)App.Current.MainWindow).ShowInputAsync("Новая запись", "Введите наименование типа",
                new MetroDialogSettings
                {
                    AffirmativeButtonText = "Ок",
                    NegativeButtonText = "Отмена"
                });
                if (!string.IsNullOrEmpty(result))
                {
                    _dataService.AddAssetType(new AssetType() { Name = result });
                    AssetsType = _dataService.GetAssetsType();
                }
            }, nameof(AddAssetType));

            EditAssetType = MakeCommand(async () =>
            {
                if (SelectAssetType != null)
                {
                    string result = await ((MetroWindow)App.Current.MainWindow).ShowInputAsync("Редактирование", "Введите наименование типа",
                                       new MetroDialogSettings
                                       {
                                           AffirmativeButtonText = "Ок",
                                           NegativeButtonText = "Отмена",
                                           DefaultText = SelectAssetType.Name
                                       });
                    if (result != SelectAssetType.Name && result != null)
                    {
                        SelectAssetType.Name = result;
                        _dataService.EditAssetType(SelectAssetType);
                        AssetsType = _dataService.GetAssetsType();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите тип");
                }
            }, nameof(EditAssetType));

            DeleteAssetType = MakeCommand(async () =>
            {
                if (SelectAssetType != null)
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
                        _dataService.DeleteAssetType(SelectAssetType);
                        AssetsType = _dataService.GetAssetsType();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите тип");
                }
            }, nameof(DeleteAssetType));

            GoBack = MakeCommand(() =>
            {
                _navigationService.GoBack();
            }, nameof(GoBack));
        }

        //public async Task Start()
        //{
        //    await LoadingData();
        //}

        //private async Task LoadingData()
        //{
        //    Departments =  _dataService.GetDepartments();
        //}

        #region Fields

        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;
        private readonly IFrameNavigationService _navigationService;
        public ObservableCollection<Department> Departments
        {
            get => Get<ObservableCollection<Department>>();
            set => Set(value);
        }

        public Department SelectDepartment
        {
            get => Get<Department>();
            set => Set(value);
        }

        public ObservableCollection<Place> Places
        {
            get => Get<ObservableCollection<Place>>();
            set => Set(value);
        }

        public Place SelectPlace
        {
            get => Get<Place>();
            set => Set(value);
        }

        public ObservableCollection<Status> Statuses
        {
            get => Get<ObservableCollection<Status>>();
            set => Set(value);
        }

        public Status SelectStatus
        {
            get => Get<Status>();
            set => Set(value);
        }

        public ObservableCollection<Asset> Assets
        {
            get => Get<ObservableCollection<Asset>>();
            set => Set(value);
        }

        public Asset SelectAsset
        {
            get => Get<Asset>();
            set => Set(value);
        }

        public ObservableCollection<AssetType> AssetsType
        {
            get => Get<ObservableCollection<AssetType>>();
            set => Set(value);
        }

        public AssetType SelectAssetType
        {
            get => Get<AssetType>();
            set => Set(value);
        }

        public ObservableCollection<Employee> Employees
        {
            get => Get<ObservableCollection<Employee>>();
            set => Set(value);
        }

        public Employee SelectEmployee
        {
            get => Get<Employee>();
            set => Set(value);
        }

        public ObservableCollection<Transfer> Transfers
        {
            get => Get<ObservableCollection<Transfer>>();
            set => Set(value);
        }

        #endregion

        #region Commands

        public ICommand AddDepartment { get; set; }
        public ICommand EditDepartment { get; set; }
        public ICommand DeleteDepartment { get; set; }
        public ICommand AddPlace { get; set; }
        public ICommand EditPlace { get; set; }
        public ICommand DeletePlace { get; set; }
        public ICommand AddStatus { get; set; }
        public ICommand EditStatus { get; set; }
        public ICommand DeleteStatus { get; set; }
        public ICommand AddAssetType { get; set; }
        public ICommand EditAssetType { get; set; }
        public ICommand DeleteAssetType { get; set; }
        public ICommand OpenAddEmployee { get; set; }
        public ICommand EditEmployee { get; set; }
        public ICommand DeleteEmployee { get; set; }
        public ICommand OpenAddAsset { get; set; }
        public ICommand EditAsset { get; set; }
        public ICommand DeleteAsset { get; set; }
        public ICommand GoBack { get; set; }

        #endregion
    }
}
