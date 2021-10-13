using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface ITechnicianFacade
    {
        Task Add(Technician technician);
    }
}
