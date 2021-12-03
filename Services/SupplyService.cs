using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services.Exceptions;

namespace Warehouse.Services
{
    public class SupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplyService(
            ISupplyRepository supplyRepository,
            IUnitOfWork unitOfWork
        )
        {
            _supplyRepository = supplyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Supply>> GetSupplies()
        {
            return await _supplyRepository.GetSupplies();
        }

        public async Task<SupplyEntry> GetSupplyEntry(int id)
        {
            var supplyEntry =
                await _supplyRepository.GetSupplyEntry(id);

            if (supplyEntry == null)
            {
                throw new SupplyEntryNotFoundException(id);
            }

            return supplyEntry;
        }

        public async Task Add(SupplyEntry supplyEntry)
        {
            supplyEntry.CreatedAt = DateTime.Now;

            await _supplyRepository.Add(supplyEntry);

            await UpdateSupplyQuantity(supplyEntry);

            await _unitOfWork.CompleteAsync();
        }

        private async Task UpdateSupplyQuantity(SupplyEntry supplyEntry)
        {
            var supply = await _supplyRepository.GetSupply(supplyEntry.ProductId);
            supply.Quantity += supplyEntry.Quantity;
        }
    }
}
