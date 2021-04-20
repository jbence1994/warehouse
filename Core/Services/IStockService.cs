using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface IStockService
    {
        Task Add(Stock stock);
    }
}
