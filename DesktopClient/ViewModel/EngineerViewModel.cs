using DesktopClient.Infrastructure.Interfaces;
using DesktopClient.Views;
using GalaSoft.MvvmLight.Views;
using Server.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DesktopClient.ViewModel
{
    public class EngineerViewModel : BaseViewModel
    {
        public EngineerViewModel(IDialogService dialogService, IDataService dataService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
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
        public ICommand AddRepair { get; set; }
        public ICommand EditRepair{ get; set; }
        public ICommand DeleteRepair { get; set; }

        #endregion
    }
}
