using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class MerchantsController : ControllerBase
    {
        private readonly MerchantService _merchantService;
        private readonly IMapper _mapper;

        public MerchantsController(
            MerchantService merchantService,
            IMapper mapper
        )
        {
            _merchantService = merchantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMerchants()
        {
            var merchants =
                await _merchantService.GetMerchants();

            var response =
                _mapper.Map<IEnumerable<Merchant>, IEnumerable<GetMerchantResponseResource>>(merchants);

            return Ok(response);
        }

        [HttpGet("merchantKeyValuePairs")]
        public async Task<IActionResult> GetMerchantKeyValuePairs()
        {
            var merchants =
                await _merchantService.GetMerchants(includeRelated: false);

            var response =
                _mapper
                    .Map<IEnumerable<Merchant>,
                        IEnumerable<GetKeyValuePairResponseResource>>(merchants);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant(
            [FromBody] CreateMerchantRequestResource request
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var merchant =
                    _mapper.Map<CreateMerchantRequestResource, Merchant>(request);

                await _merchantService.Add(merchant);

                merchant =
                    await _merchantService.GetMerchant(merchant.Id);

                var response =
                    _mapper.Map<Merchant, GetMerchantResponseResource>(merchant);

                return Ok(response);
            }
            catch (MerchantNotFoundException merchantNotFoundException)
            {
                return NotFound(merchantNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
