using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MerchantsController(
            IMerchantRepository merchantRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _merchantRepository = merchantRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMerchants()
        {
            var merchants = await _merchantRepository.GetMerchants();

            var merchantResources =
                _mapper.Map<IEnumerable<Merchant>, IEnumerable<MerchantResource>>(merchants);

            return Ok(merchantResources);
        }

        [HttpGet("merchantKeyValuePairs")]
        public async Task<IActionResult> GetMerchantKeyValuePairs()
        {
            var merchants = await _merchantRepository.GetMerchants(includeRelated: false);

            var merchantResources =
                _mapper.Map<IEnumerable<Merchant>, IEnumerable<KeyValuePairResource>>(merchants);

            return Ok(merchantResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] SaveMerchantResource saveMerchantResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchant = _mapper.Map<SaveMerchantResource, Merchant>(saveMerchantResource);

            await _merchantRepository.Add(merchant);
            await _unitOfWork.CompleteAsync();

            merchant = await _merchantRepository.GetMerchant(merchant.Id);

            var result = _mapper.Map<Merchant, MerchantResource>(merchant);

            return Ok(result);
        }
    }
}
