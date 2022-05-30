using System;
using System.Windows.Controls;
using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Server.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DesktopClient.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IDialogService dialogService, IFrameNavigationService navigationService, IDataService dataService)
        {
            InitCommands();

            _dialogService = dialogService;
            _navigationService = navigationService;
            _dataService = dataService;
            DateEnd = DateTime.Now;
            SettingsView = "Visible";
            ServerAddress = "https://84.135.94.126:5001/";
            DbName = "MainDB";
        }

        #region Fields

        private readonly IDialogService _dialogService;
        private readonly IFrameNavigationService _navigationService;
        private readonly IDataService _dataService;

        #endregion

        #region Properties

        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        public string ServerAddress
        {
            get => Get<string>();
            set => Set(value);
        }
        public string DbName
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool Information
        {
            get => Get(false);
            set => Set(value);
        }
        public bool Settings
        {
            get => Get(false);
            set => Set(value);
        }
        public bool EmployeeAdd
        {
            get => Get(false);
            set => Set(value);
        }

        public bool EmployeeEdit
        {
            get => Get(false);
            set => Set(value);
        }

        public Employee empl
        {
            get => Get<Employee>();
            set => Set(value);
        }
        public Detail det
        {
            get => Get<Detail>();
            set => Set(value);
        }
        public Service ser
        {
            get => Get<Service>();
            set => Set(value);
        }
        public Place placetemp
        {
            get => Get<Place>();
            set => Set(value);
        }

        public ObservableCollection<Department> Departments
        {
            get => Get<ObservableCollection<Department>>();
            set => Set(value);
        }

        public ObservableCollection<AssetType> AssetTypes
        {
            get => Get<ObservableCollection<AssetType>>();
            set => Set(value);
        }

        public ObservableCollection<Status> Statuses
        {
            get => Get<ObservableCollection<Status>>();
            set => Set(value);
        }

        public ObservableCollection<Place> Places
        {
            get => Get<ObservableCollection<Place>>();
            set => Set(value);
        }

        public ObservableCollection<Employee> empls
        {
            get => Get<ObservableCollection<Employee>>();
            set => Set(value);
        }

        public bool AssetAdd
        {
            get => Get(false);
            set => Set(value);
        }
        public bool AssetFilter
        {
            get => Get(false);
            set => Set(value);
        }

        public bool AssetEdit
        {
            get => Get(false);
            set => Set(value);
        }

        public bool DetailAdd
        {
            get => Get(false);
            set => Set(value);
        }

        public bool ServiceAdd
        {
            get => Get(false);
            set => Set(value);
        }

        public bool DetailEdit
        {
            get => Get(false);
            set => Set(value);
        }

        public bool ServiceEdit
        {
            get => Get(false);
            set => Set(value);
        }

        public Asset asst
        {
            get => Get<Asset>();
            set => Set(value);
        }

        public string SettingsView
        {
            get => Get<string>();
            set => Set(value);
        }
        public DateTime DateEnd { get; set; }

        #endregion

        #region Commands

        public ICommand AuthorizationCommand { get; set; }
        public ICommand ShowInformation { get; set; }
        public ICommand ShowSettings { get; set; }
        public ICommand CancelAddEmp { get; set; }
        public ICommand AddEmp { get; set; }
        public ICommand CancelEditEmp { get; set; }
        public ICommand EditEmp { get; set; }
        public ICommand AddAsset { get; set; }
        public ICommand EditAsset { get; set; }
        public ICommand UploadAsset { get; set; }
        public ICommand CancelAddAsset { get; set; }
        public ICommand CancelEditAsset { get; set; }
        public ICommand CancelFilterAsset { get; set; }
        public ICommand CancelAddDetail { get; set; }
        public ICommand AddDetail { get; set; }
        public ICommand EditDetail { get; set; }
        public ICommand CancelEditDetail { get; set; }
        public ICommand CancelAddService { get; set; }
        public ICommand AddService { get; set; }
        public ICommand EditService { get; set; }
        public ICommand CancelEditService { get; set; }
        #endregion

        #region Commands

        private void InitCommands()
        {
            AuthorizationCommand = MakeCommand((pb) =>
            {
                Authorization((PasswordBox)pb);
            }, nameof(AuthorizationCommand));
            ShowInformation = MakeCommand(() =>
            {
                Information = true;
            }, nameof(ShowInformation));
            ShowSettings = MakeCommand(() =>
            {
                Settings = true;
            }, nameof(ShowSettings));
            AddEmp = MakeCommand(async () =>
            {
                if (empl.Department != null && !string.IsNullOrEmpty(empl.FirstName) && !string.IsNullOrEmpty(empl.LastName))
                {
                    Employee item = new Employee() { FirstName = empl.FirstName, LastName = empl.LastName, MiddleName = empl.MiddleName, Department = empl.Department };
                    _dataService.AddEmployee(item);
                    EmployeeAdd = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).ChiefView.Employees = _dataService.GetEmployees();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(AddEmp));
            CancelAddEmp = MakeCommand(() =>
            {
                EmployeeAdd = false;
            }, nameof(CancelAddEmp));

            CancelEditEmp = MakeCommand(() =>
            {
                EmployeeEdit = false;
            }, nameof(CancelEditEmp));

            EditEmp = MakeCommand(async () =>
            {
                if (empl != null)
                {
                    _dataService.EditEmployee(empl);
                    EmployeeEdit = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).ChiefView.Employees = _dataService.GetEmployees();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(EditEmp));
            AddAsset = MakeCommand(async () =>
            {
                if (asst.Place != null && asst.Status != null && asst.Employee != null && asst.AssetType != null && !string.IsNullOrEmpty(asst.Name) && !string.IsNullOrEmpty(asst.InventoryNumber))
                {
                    Asset item = new Asset()
                    {
                        Name = asst.Name,
                        InventoryNumber = asst.InventoryNumber,
                        SerialNumber = asst.SerialNumber,
                        Status = asst.Status,
                        Employee = asst.Employee,
                        Place = asst.Place,
                        Date = asst.Date,
                        DateCreate = asst.DateCreate,
                        AssetType = asst.AssetType,
                        Description = asst.Description
                    };
                    _dataService.AddAsset(item);
                    ((ViewModelLocator)App.Current.Resources["Locator"]).ChiefView.Assets = _dataService.GetAssets();
                    AssetAdd = false;
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(AddAsset));
            EditAsset = MakeCommand(async () =>
            {
                if (asst != null)
                {                    
                    if(placetemp!=asst.Place)
                    {
                        Transfer transfer = new Transfer() { Asset = asst, Date = DateTime.Now, PlaceOld = placetemp, PlaceNew = asst.Place, Description = asst.Description };
                        _dataService.AddTransfer(transfer);
                        ((ViewModelLocator)App.Current.Resources["Locator"]).ChiefView.Transfers = _dataService.GetTransfers();
                    }
                    _dataService.EditAsset(asst);
                    AssetEdit = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).ChiefView.Assets = _dataService.GetAssets();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(EditAsset));
            CancelEditAsset = MakeCommand(() =>
            {
                AssetEdit = false;
            }, nameof(CancelEditAsset));
            CancelAddAsset = MakeCommand(() =>
            {
                AssetAdd = false;
            }, nameof(CancelAddAsset));
            CancelFilterAsset = MakeCommand(() =>
            {
                AssetFilter = false;
            }, nameof(CancelFilterAsset));
            UploadAsset = MakeCommand(async () =>
            {
                try
                {
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(@"C:\Dip\Imuchestvo.docx")
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                    AssetFilter = false;
                }
                catch (Exception e)
                {
                    await _dialogService.ShowMessage("Ошибка", e.Message);
                }
            }, nameof(UploadAsset));
            AddDetail = MakeCommand(async() =>
            {
                if (!string.IsNullOrEmpty(det.Name))
                {
                    Detail item = new Detail() { Name = det.Name, Price = det.Price };
                    _dataService.AddDetail(item);
                    DetailAdd = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).EngineerView.Details = _dataService.GetDetails();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(AddDetail));
            CancelAddDetail = MakeCommand(() =>
            {
                DetailAdd = false;
            }, nameof(CancelAddDetail));
            EditDetail = MakeCommand(async () =>
            {
                if (det != null)
                {
                    _dataService.EditDetail(det);
                    DetailEdit = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).EngineerView.Details = _dataService.GetDetails();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(EditDetail));
            AddService = MakeCommand(async () =>
            {
                if (!string.IsNullOrEmpty(ser.Name))
                {
                    Service item = new Service() { Name = ser.Name, Price = ser.Price };
                    _dataService.AddService(item);
                    ServiceAdd = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).EngineerView.Services = _dataService.GetServices();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(AddService));
            CancelAddService = MakeCommand(() =>
            {
                ServiceAdd = false;
            }, nameof(CancelAddService));
            EditService = MakeCommand(async () =>
            {
                if (ser != null)
                {
                    _dataService.EditService(ser);
                    ServiceEdit = false;
                    ((ViewModelLocator)App.Current.Resources["Locator"]).EngineerView.Services = _dataService.GetServices();
                }
                else
                    await _dialogService.ShowMessage("Ошибка", "Заполните обязательные поля");
            }, nameof(EditService));
            CancelEditDetail = MakeCommand(() =>
            {
                DetailEdit = false;
            }, nameof(CancelEditDetail));
            CancelEditService = MakeCommand(() =>
            {
                ServiceEdit = false;
            }, nameof(CancelEditService));
        }

        private void Authorization(PasswordBox passwordBox)
        {
            string password = passwordBox.Password ?? "";
            Authorization(Login, password);
            passwordBox.Password = string.Empty;
            Login = string.Empty;
        }

        private void Authorization(string login, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    throw new FormatException();
                LoginSuccess(login, password);                
            }
            catch (FormatException)
            {
                _dialogService.ShowMessage("Неверные параметры", "Пожалуйста проверьте правильность логина и пароля!");
            }
            catch (Exception)
            {
                _dialogService.ShowMessage("Упс...", "Что-то пошло не так!");
            }
        }

        private void LoginSuccess(string login, string password)
        {
            if (ServerAddress == "https://84.135.94.126:5001/" && DbName == "MainDB")
            {
                if (login == "1" && password == "1")
                {
                    _navigationService.NavigateTo("ChiefView");
                }
                else if (login == "2" && password == "2")
                {
                    _navigationService.NavigateTo("EngineerView");
                }
                else if (login == "3" && password == "3")
                {
                    _navigationService.NavigateTo("EmployeeView");
                }
                else
                    _dialogService.ShowMessage("Неверные параметры", "Проверьте логин и пароль");
                SettingsView = "Hidden";
            }
            else _dialogService.ShowMessage("Упс...", "Проверьте доступность сервера или бд");
        }

        #endregion
    }
}