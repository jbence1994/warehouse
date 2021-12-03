using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services.Exceptions;

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

        public async Task<IEnumerable<Merchant>> GetMerchants(bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await _merchantRepository.GetMerchants();
            }

            return await _merchantRepository.GetMerchants(includeRelated: false);
        }

        public async Task<Merchant> GetMerchant(int id)
        {
            var merchant = await _merchantRepository.GetMerchant(id);

            if (merchant == null)
            {
                throw new MerchantNotFoundException(id);
            }

            return merchant;
        }

        public async Task Add(Merchant merchant)
        {
            await _merchantRepository.Add(merchant);
            await _unitOfWork.CompleteAsync();
        }
    }
}
