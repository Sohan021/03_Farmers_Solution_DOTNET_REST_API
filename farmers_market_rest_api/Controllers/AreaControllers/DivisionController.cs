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
    public class DivisionController : Controller
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DivisionController(IDivisionRepository divisionRepository,
                                 IUnitOfWork unitOfWork)
        {
            _divisionRepository = divisionRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<Division>> GetAllAsync()
        {
            var divisions = await _divisionRepository.ListAsync();

            return divisions;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var division = await _divisionRepository.FindByIdAsync(id);

            return Ok(division);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Division division)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _divisionRepository.AddAsync(division);
                await _unitOfWork.CompleteAsync();
                return Ok(division);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Division division)
        {
            var existingDivision = await _divisionRepository.FindByIdAsync(id);

            if (existingDivision == null)
                return StatusCode(500, "Counntry not found");

            existingDivision.Name = division.Name;
            existingDivision.DivisionCode = division.DivisionCode;

            try
            {
                _divisionRepository.Update(existingDivision);
                await _unitOfWork.CompleteAsync();
                return Ok(division);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingDivision = await _divisionRepository.FindByIdAsync(id);

            try
            {
                _divisionRepository.Remove(existingDivision);
                await _unitOfWork.CompleteAsync();

                return Ok(existingDivision);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
