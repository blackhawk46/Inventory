using DesktopClient.Infrastructure.Interfaces;
using Server;
using Server.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopClient.Infrastructure.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _data = new DataContext();
        //private readonly string ServerUrl = "https://localhost:5001/";
        //private static HttpClient ApiClient { get; set; }

        public DataService()
        {
        }

        public ObservableCollection<Department> GetDepartments()
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department>();

            //departments = _data.Departments.Local.ToObservableCollection();

            List<Department> deps = _data.Departments.ToList();

            for (int i = 0; i < deps.Count; i++)
            {
                departments.Add(deps[i]);
            }

            //for (int i = 0; i < departments.Count; i++)
            //{
            //    departments.Add(departments[i]);
            //}

            return departments;

            //return _data.Departments.Local.ToObservableCollection();           
        }

        public void AddDepartment(Department department)
        {
            _data.Departments.Add(department);
            _data.SaveChanges();
        }

        public void EditDepartment(Department department)
        {
            _data.Departments.Update(department);
            _data.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            _data.Departments.Remove(department);
            _data.SaveChanges();
        }

        public ObservableCollection<Place> GetPlaces()
        {
            ObservableCollection<Place> places = new ObservableCollection<Place>();

            List<Place> pl = _data.Places.ToList();

            for (int i = 0; i < pl.Count; i++)
            {
                places.Add(pl[i]);
            }

            return places;
        }

        public void AddPlace(Place place)
        {
            _data.Places.Add(place);
            _data.SaveChanges();
        }

        public void EditPlace(Place place)
        {
            _data.Places.Update(place);
            _data.SaveChanges();
        }

        public void DeletePlace(Place place)
        {
            _data.Places.Remove(place);
            _data.SaveChanges();
        }

        public ObservableCollection<Status> GetStatuses()
        {
            ObservableCollection<Status> statuses = new ObservableCollection<Status>();

            List<Status> st = _data.Statuses.ToList();

            for (int i = 0; i < st.Count; i++)
            {
                statuses.Add(st[i]);
            }

            return statuses;
        }

        public void AddStatus(Status status)
        {
            _data.Statuses.Add(status);
            _data.SaveChanges();
        }

        public void EditStatus(Status status)
        {
            _data.Statuses.Update(status);
            _data.SaveChanges();
        }

        public void DeleteStatus(Status status)
        {
            _data.Statuses.Remove(status);
            _data.SaveChanges();
        }

        public ObservableCollection<Asset> GetAssets()
        {
            ObservableCollection<Asset> assets = new ObservableCollection<Asset>();

            List<Asset> ass = _data.Assets.ToList();

            for (int i = 0; i < ass.Count; i++)
            {
                assets.Add(ass[i]);
            }

            return assets;
        }

        public void AddAsset(Asset asset)
        {
            _data.Assets.Add(asset);
            _data.SaveChanges();
        }

        public void EditAsset(Asset asset)
        {
            _data.Assets.Update(asset);
            _data.SaveChanges();
        }

        public void DeleteAsset(Asset asset)
        {
            _data.Assets.Remove(asset);
            _data.SaveChanges();
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            List<Employee> emp = _data.Employees.ToList();

            for (int i = 0; i < emp.Count; i++)
            {
                employees.Add(emp[i]);
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            _data.Employees.Add(employee);
            _data.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            _data.Employees.Update(employee);
            _data.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _data.Employees.Remove(employee);
            _data.SaveChanges();
        }

        public ObservableCollection<AssetType> GetAssetsType()
        {
            ObservableCollection<AssetType> assettypes = new ObservableCollection<AssetType>();

            List<AssetType> ast = _data.AssetTypes.ToList();

            for (int i = 0; i < ast.Count; i++)
            {
                assettypes.Add(ast[i]);
            }

            return assettypes;
        }

        public void AddAssetType(AssetType assetType)
        {
            _data.AssetTypes.Add(assetType);
            _data.SaveChanges();
        }

        public void EditAssetType(AssetType assetType)
        {
            _data.AssetTypes.Update(assetType);
            _data.SaveChanges();
        }

        public void DeleteAssetType(AssetType assetType)
        {
            _data.AssetTypes.Remove(assetType);
            _data.SaveChanges();
        }

        public ObservableCollection<Transfer> GetTransfers()
        {
            ObservableCollection<Transfer> trnfs = new ObservableCollection<Transfer>();

            List<Transfer> tr = _data.Transfers.ToList();

            for (int i = 0; i < tr.Count; i++)
            {
                trnfs.Add(tr[i]);
            }

            return trnfs;
        }

        public void AddTransfer(Transfer transfer)
        {
            _data.Transfers.Add(transfer);
            _data.SaveChanges();
        }

        public ObservableCollection<Detail> GetDetails()
        {
            ObservableCollection<Detail> dtls = new ObservableCollection<Detail>();

            List<Detail> dt = _data.Details.ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                dtls.Add(dt[i]);
            }

            return dtls;
        }

        public void AddDetail(Detail detail)
        {
            _data.Details.Add(detail);
            _data.SaveChanges();
        }

        public void EditDetail(Detail detail)
        {
            _data.Details.Update(detail);
            _data.SaveChanges();
        }

        public void DeleteDetail(Detail detail)
        {
            _data.Details.Remove(detail);
            _data.SaveChanges();
        }

        public ObservableCollection<Service> GetServices()
        {
            ObservableCollection<Service> srvs = new ObservableCollection<Service>();

            List<Service> sv = _data.Services.ToList();

            for (int i = 0; i < sv.Count; i++)
            {
                srvs.Add(sv[i]);
            }

            return srvs;
        }

        public void AddService(Service service)
        {
            _data.Services.Add(service);
            _data.SaveChanges();
        }

        public void EditService(Service service)
        {
            _data.Services.Update(service);
            _data.SaveChanges();
        }

        public void DeleteService(Service service)
        {
            _data.Services.Remove(service);
            _data.SaveChanges();
        }

        public ObservableCollection<Repair> GetRepairs()
        {
            ObservableCollection<Repair> rps = new ObservableCollection<Repair>();

            List<Repair> rp = _data.Repairs.ToList();

            for (int i = 0; i < rp.Count; i++)
            {
                rps.Add(rp[i]);
            }

            return rps;
        }

        public void AddRepair(Repair repair)
        {
            _data.Repairs.Add(repair);
            _data.SaveChanges();
        }

        public void EditRepair(Repair repair)
        {
            _data.Repairs.Update(repair);
            _data.SaveChanges();
        }

        public void DeleteRepair(Repair repair)
        {
            _data.Repairs.Remove(repair);
            _data.SaveChanges();
        }

        public ObservableCollection<RepairHistory> GetRepairHistory()
        {
            ObservableCollection<RepairHistory> rps = new ObservableCollection<RepairHistory>();

            List<RepairHistory> rp = _data.RepairHistory.ToList();

            for (int i = 0; i < rp.Count; i++)
            {
                rps.Add(rp[i]);
            }

            return rps;
        }

        public void AddRepairHistory(RepairHistory repairHistory)
        {
            _data.RepairHistory.Add(repairHistory);
        }
    }
}
