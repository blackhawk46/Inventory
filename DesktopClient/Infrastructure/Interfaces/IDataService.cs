using Server.Models;
using System.Collections.ObjectModel;

namespace DesktopClient.Infrastructure.Interfaces
{
    public interface IDataService
    {
        ObservableCollection<Department> GetDepartments();
        void AddDepartment(Department department);
        void EditDepartment(Department department);
        void DeleteDepartment(Department department);
        ObservableCollection<Place> GetPlaces();
        void AddPlace(Place place);
        void EditPlace(Place place);
        void DeletePlace(Place place);
        ObservableCollection<Status> GetStatuses();
        void AddStatus(Status status);
        void EditStatus(Status status);
        void DeleteStatus(Status status);
        ObservableCollection<AssetType> GetAssetsType();
        void AddAssetType(AssetType assetType);
        void EditAssetType(AssetType assetType);
        void DeleteAssetType(AssetType assetType);
        ObservableCollection<Asset> GetAssets();
        void AddAsset(Asset asset);
        void EditAsset(Asset asset);
        void DeleteAsset(Asset asset);
        ObservableCollection<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void EditEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        ObservableCollection<Transfer> GetTransfers();
        void AddTransfer(Transfer transfer);
        ObservableCollection<Detail> GetDetails();
        void AddDetail(Detail detail);
        void EditDetail(Detail detail);
        void DeleteDetail(Detail detail);
        ObservableCollection<Service> GetServices();
        void AddService(Service service);
        void EditService(Service service);
        void DeleteService(Service service);
        ObservableCollection<Repair> GetRepairs();
        void AddRepair(Repair repair);
        void EditRepair(Repair repair);
        void DeleteRepair(Repair repair);
    }
}
