using Server.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DesktopClient.Infrastructure.Interfaces
{
    public interface IDataService
    {
        Task<ObservableCollection<Department>> GetDepartments();
    }
}
