using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IProductPhotoRepository
    {
        Task<IEnumerable<ProductPhoto>> GetPhotos();
    }
}
