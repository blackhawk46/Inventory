﻿using DesktopClient.Infrastructure.Interfaces;
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
            throw new System.NotImplementedException();
        }

        public void AddAsset(Asset asset)
        {
            throw new System.NotImplementedException();
        }

        public void EditAsset(Asset asset)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAsset(Asset asset)
        {
            throw new System.NotImplementedException();
        }
    }
}
