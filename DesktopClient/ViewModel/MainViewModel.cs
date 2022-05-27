using System;
using System.Windows.Controls;
using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Server.Models;
using System.Collections.ObjectModel;

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

        public bool Information
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

        public bool AssetEdit
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
        public ICommand CancelAddEmp { get; set; }
        public ICommand AddEmp { get; set; }
        public ICommand CancelEditEmp { get; set; }
        public ICommand EditEmp { get; set; }
        public ICommand AddAsset { get; set; }
        public ICommand CancelAddAsset { get; set; }

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
            AddEmp = MakeCommand(async () =>
            {
                if (empl.Department != null && !string.IsNullOrEmpty(empl.FirstName) && !string.IsNullOrEmpty(empl.LastName))
                {
                    Employee item = new Employee() { FirstName = empl.FirstName, LastName = empl.LastName, MiddleName = empl.MiddleName, Department = empl.Department};
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
            AddAsset = MakeCommand(() =>
            {

                AssetAdd = false;
            }, nameof(AddAsset));
            CancelAddAsset = MakeCommand(() =>
            {
                AssetAdd = false;
            }, nameof(CancelAddAsset));
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
                SettingsView = "Hidden";
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
            if (login == "1" && password == "1")
            {
                _navigationService.NavigateTo("ChiefView");
            }
            else if (login == "Инженер" && password == "456")
            {
                _navigationService.NavigateTo("EngineerView");
            }
            else if (login == "Сотрудник" && password == "789")
            {
                _navigationService.NavigateTo("EmployeeView");
            }
            else
                _dialogService.ShowMessage("Неверные параметры", "Проверьте логин и пароль");

        }

        #endregion
    }
}