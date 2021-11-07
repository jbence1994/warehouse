using System;
using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Services
{
    public class SupplyOperations
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyOperations(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public async Task Add(SupplyEntry supplyEntry)
        {
            supplyEntry.CreatedAt = DateTime.Now;

            await _supplyRepository.Add(supplyEntry);

            await UpdateSupplyQuantity(supplyEntry);
        }

        private async Task UpdateSupplyQuantity(SupplyEntry supplyEntry)
        {
            var supply = await _supplyRepository.GetSupply(supplyEntry.ProductId);
            supply.Quantity += supplyEntry.Quantity;
        }
    }
}
