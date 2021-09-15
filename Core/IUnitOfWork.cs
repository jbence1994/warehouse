using System.Threading.Tasks;

namespace Warehouse.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
