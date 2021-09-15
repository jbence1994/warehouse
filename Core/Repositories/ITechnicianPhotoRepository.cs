using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ITechnicianPhotoRepository
    {
        Task<IEnumerable<TechnicianPhoto>> GetPhotos(int technicianId);
    }
}
