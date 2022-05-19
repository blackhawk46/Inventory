using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Server.Models;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace DesktopClient.ViewModel
{
    public class ChiefViewModel : BaseViewModel
    {
        public ChiefViewModel(IDialogService dialogService, IDataService dataService)
        {
            InitCommands();

            _dataService = dataService;
            _dialogService = dialogService;

            Departments = _dataService.GetDepartments();
            Places = _dataService.GetPlaces();
            Statuses = _dataService.GetStatuses();
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
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Введите наименование отдела");
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
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Введите наименование местоположения");
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
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Введите наименование статуса");
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
        public ICommand AddAsset { get; set; }
        public ICommand EditAsset { get; set; }
        public ICommand DeleteAsset { get; set; }

        #endregion
    }
}
