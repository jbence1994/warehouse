using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
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
                _mapper.Map<IEnumerable<Merchant>, IEnumerable<MerchantResponse>>(merchants);

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
                        IEnumerable<KeyValuePairResponse>>(merchants);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant(
            [FromBody] CreateMerchantRequest request
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var merchant =
                    _mapper.Map<CreateMerchantRequest, Merchant>(request);

                await _merchantService.Add(merchant);

                merchant =
                    await _merchantService.GetMerchant(merchant.Id);

                var response =
                    _mapper.Map<Merchant, MerchantResponse>(merchant);

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
