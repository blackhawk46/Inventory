using System;
using System.Windows.Controls;
using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;

namespace DesktopClient.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IDialogService dialogService, IFrameNavigationService navigationService)
        {
            InitCommands();

            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        #region Fields

        private readonly IDialogService _dialogService;
        private readonly IFrameNavigationService _navigationService;

        #endregion

        #region Properties

        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        #endregion

        #region Commands

        public ICommand AuthorizationCommand { get; set; }

        #endregion

        #region Commands

        private void InitCommands()
        {
            AuthorizationCommand = MakeCommand((pb) =>
            {
                Authorization((PasswordBox)pb);
            }, nameof(AuthorizationCommand));
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