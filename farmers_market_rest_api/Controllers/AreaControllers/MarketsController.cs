using farmers_market_rest_api.Domain.IRepository.Area;
using farmers_market_rest_api.Domain.Models.Area;
using farmers_market_rest_api.Persistence.Utils.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.AreaControllers
{
    [Route("/api/[controller]")]
    public class MarketsController : Controller
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarketsController(IMarketRepository marketRepository,
                                 IUnitOfWork unitOfWork)
        {
            _marketRepository = marketRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<Market>> GetAllAsync()
        {
            var markets = await _marketRepository.ListAsync();

            return markets;

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var market = await _marketRepository.FindByIdAsync(id);

            return Ok(market);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Market market)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _marketRepository.AddAsync(market);
                await _unitOfWork.CompleteAsync();
                return Ok(market);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Market market)
        {
            var existingMarket = await _marketRepository.FindByIdAsync(id);

            if (existingMarket == null)
                return StatusCode(500, "Counntry not found");

            existingMarket.Name = market.Name;
            existingMarket.MarketCode = market.MarketCode;

            try
            {
                _marketRepository.Update(existingMarket);
                await _unitOfWork.CompleteAsync();
                return Ok(market);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingMarket = await _marketRepository.FindByIdAsync(id);

            try
            {
                _marketRepository.Remove(existingMarket);
                await _unitOfWork.CompleteAsync();

                return Ok(existingMarket);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
