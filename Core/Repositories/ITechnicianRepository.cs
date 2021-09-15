using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ITechnicianRepository
    {
        Task<IEnumerable<Technician>> GetTechnicians();
        Task<Technician> GetTechnician(int id);
        Task Add(Technician technician);
    }
}
