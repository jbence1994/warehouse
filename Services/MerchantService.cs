using Warehouse.Core;
using Warehouse.Core.Repositories;

namespace Warehouse.Services
{
    public class MerchantService
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MerchantService(
            IMerchantRepository merchantRepository,
            IUnitOfWork unitOfWork
        )
        {
            _merchantRepository = merchantRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
