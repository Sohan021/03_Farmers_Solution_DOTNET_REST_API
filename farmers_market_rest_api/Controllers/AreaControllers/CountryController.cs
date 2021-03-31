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
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(ICountryRepository countryRepository,
                                 IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var countries = await _countryRepository.ListAsync();

            return countries;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var country = await _countryRepository.FindByIdAsync(id);

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _countryRepository.AddAsync(country);
                await _unitOfWork.CompleteAsync();
                return Ok(country);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Country country)
        {
            var existingCountry = await _countryRepository.FindByIdAsync(id);

            if (existingCountry == null)
                return StatusCode(500, "Counntry not found");

            existingCountry.Name = country.Name;
            existingCountry.CountryCode = country.CountryCode;

            try
            {
                _countryRepository.Update(existingCountry);
                await _unitOfWork.CompleteAsync();
                return Ok(country);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingCountry = await _countryRepository.FindByIdAsync(id);

            try
            {
                _countryRepository.Remove(existingCountry);
                await _unitOfWork.CompleteAsync();

                return Ok(existingCountry);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
