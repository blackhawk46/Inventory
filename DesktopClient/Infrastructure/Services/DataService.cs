using DesktopClient.Infrastructure.Interfaces;
using Newtonsoft.Json;
using Server.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;

namespace DesktopClient.Infrastructure.Services
{
    public class DataService : IDataService
    {
        //private readonly DataContext _data = new DataContext();
        private readonly string ServerUrl = "https://localhost:5001/";
        private static HttpClient ApiClient { get; set; }

        public DataService()
        {
            InitApi();
        }

        private void InitApi()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<Department>> GetDepartments()
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department>();

            try
            {
                using (HttpResponseMessage responseMessage = await ApiClient.GetAsync("https://localhost:5001/api/departments/"))
                {
                    if(responseMessage.IsSuccessStatusCode)
                    {
                        var dataObjects = responseMessage.Content.ReadAsAsync<IEnumerable<Department>>().Result;
                        foreach (var dataObject in dataObjects)
                        {
                            departments.Add(new Department()
                            {
                                Id = dataObject.Id,
                                Name = dataObject.Name
                            });
                        }

                        return departments;
                    }
                }
                    //using (HttpClient httpClient = new HttpClient())
                    //{
                    //HttpResponseMessage response = await client.GetAsync(ServerUrl);

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var dataObjects = JsonConvert.DeserializeObject<Department>(response);
                    //    foreach (var d in dataObjects)
                    //    {

                    //    }
                    //}

                    //string resources = await httpClient.GetStringAsync("https://localhost:5001/api/departments/");
                    //dynamic data = JsonConvert.DeserializeObject<Department>(resources);

                    //for (int i = 0; i < 2; i++)
                    //{
                    //    departments.Add(new Department()
                    //    {
                    //        //Id = data.Id,
                    //        Name = "33"
                    //    }); ;
                    //}
                    //string resources2 = await ApiClient.GetStringAsync("https://localhost:5000/api/departments/");
                    //string resources3 = await ApiClient.GetStringAsync("https://localhost:5001/api/departments/");

                    //departments.Add(new Department() { Id = 1, Name = "Super" });
                    //departments.Add(new Department() { Id = 2, Name = "Puper" });

                    //foreach (var loaddata in data)
                    //{
                    //    departments.Add(new Department()
                    //    {
                    //        Id = loaddata.Id,
                    //        Name = loaddata.Name
                    //    });
                    //}

                    //departments.RemoveAt(0);

                    return departments;
                //}
            }
            catch (System.Exception)
            {
                throw;
            }
            //    //ObservableCollection<Department> departments = new ObservableCollection<Department>();

            //    //departments.Add(new Department() { Name = "GG" });
            //    //departments.Add(new Department() { Name = "WP" });

            //    //return departments;
            //    //return new ObservableCollection<Department>(_data.Departments);
            //return departments;
        }


            //public async Task<ObservableCollection<Department>> GetDepartments()
            //{
            //    ObservableCollection<Department> departments = new ObservableCollection<Department>();

            //    string resources = await client.GetStringAsync("https://localhost:5001/api/departments/");
            //    dynamic data = JsonConvert.DeserializeObject(resources);

            //if(data==null)
            //    departments.Add(new Department()
            //    {
            //        Name = "Null"
            //    });

            //foreach (var item in data)
            //{
            //    departments.Add(new Department()
            //    {
            //        Id = data.Id,
            //        Name = data.Name
            //    });
            //}

            //using (HttpClient httpClient = new HttpClient())
            //{
            //string resources = await httpClient.GetStringAsync("https://localhost:5001/api/departments/");
            //dynamic data = JsonConvert.DeserializeObject(resources);

            //foreach (var loaddata in data)
            //{
            //    departments.Add(new Department()
            //    {
            //        Id = loaddata.Id,
            //        Name = loaddata.Name
            //    });
            //}

            //departments.Add(new Department() { Id = 1, Name = "GG" });
            //departments.Add(new Department() { Id = 2, Name = "WP" });

            //foreach (var loaddata in data)
            //{
            //    departments.Add(new Department()
            //    {
            //        Id = loaddata.Id,
            //        Name = loaddata.Name
            //    });
            //}

            //departments.RemoveAt(0);

            //return departments;
            //}
            //}

            //public void AddDepartment(Department department)
            //{
            //    //_data.Departments.Add(department);
            //}

            //public void EditDepartment(Department department)
            //{
            //    //_data.Departments.Update(department);
            //}


            //public void DeleteDepartment(Department department)
            //{
            //    //_data.Departments.Remove(department);
            //}

            //public void Save()
            //{
            //    //_data.SaveChanges();
            //}
        }
}
