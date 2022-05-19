﻿using Server.Models;
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
        ObservableCollection<Asset> GetAssets();
        void AddAsset(Asset asset);
        void EditAsset(Asset asset);
        void DeleteAsset(Asset asset);
    }
}
