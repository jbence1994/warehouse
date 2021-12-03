using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id, bool includeRelated = true);
        Task<IEnumerable<ProductPhoto>> GetPhotos();
        Task Add(Product product);
    }
}
