using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ITechnicianBalanceRepository
    {
        Task Add(TechnicianBalance technicianBalance);
    }
}
