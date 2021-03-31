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
    public class DistrictsController : Controller
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DistrictsController(IDistrictRepository districtRepository,
                                 IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<District>> GetAllAsync()
        {
            var districts = await _districtRepository.ListAsync();

            return districts;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var district = await _districtRepository.FindByIdAsync(id);

            return Ok(district);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]District district)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _districtRepository.AddAsync(district);
                await _unitOfWork.CompleteAsync();
                return Ok(district);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] District district)
        {
            var existingDistrict = await _districtRepository.FindByIdAsync(id);

            if (existingDistrict == null)
                return StatusCode(500, "Counntry not found");

            existingDistrict.Name = district.Name;
            existingDistrict.DistrictCode = district.DistrictCode;

            try
            {
                _districtRepository.Update(existingDistrict);
                await _unitOfWork.CompleteAsync();
                return Ok(district);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingDistrict = await _districtRepository.FindByIdAsync(id);

            try
            {
                _districtRepository.Remove(existingDistrict);
                await _unitOfWork.CompleteAsync();

                return Ok(existingDistrict);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
