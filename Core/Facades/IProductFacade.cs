using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface IProductFacade
    {
        Task Add(Product product);
    }
}
