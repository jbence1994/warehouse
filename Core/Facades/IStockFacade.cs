using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface IStockFacade
    {
        Task Add(Stock stock);
    }
}
