using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task Add(Product product);
    }
}
