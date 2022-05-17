using DesktopClient.Views;
using DesktopClient.Infrastructure.Interfaces;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Server.Models;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace DesktopClient.ViewModel
{
    public class ChiefViewModel : BaseViewModel
    {
        public ChiefViewModel(IDialogService dialogService, IDataService dataService)
        {
            InitCommands();

            _dataService = dataService;
            _dialogService = dialogService;

            Start();
        }

        private void InitCommands()
        {
            AddDepartment = MakeCommand(async () =>
            {
                Start();
            }, nameof(AddDepartment));
            EditDepartment = MakeCommand(() =>
            {

            }, nameof(EditDepartment));
            DeleteDepartment = MakeCommand(() =>
            {

            }, nameof(DeleteDepartment));
        }

        public async Task Start()
        {
            await LoadingData();
        }

        private async Task LoadingData()
        {
            Departments = await _dataService.GetDepartments();
        }

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

        #endregion

        #region Commands

        public ICommand AddDepartment { get; set; }
        public ICommand EditDepartment { get; set; }
        public ICommand DeleteDepartment { get; set; }
        public ICommand OpenAddDepartment { get; set; }
        public ICommand OpenEditDepartment { get; set; }

        #endregion
    }
}
