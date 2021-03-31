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
    public class UpozilasController : Controller
    {
        private readonly IUpozilaRepository _upozilaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpozilasController(IUpozilaRepository upozilaRepository,
                                 IUnitOfWork unitOfWork)
        {
            _upozilaRepository = upozilaRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<Upozila>> GetAllAsync()
        {
            var upozilas = await _upozilaRepository.ListAsync();

            return upozilas;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var upozila = await _upozilaRepository.FindByIdAsync(id);

            return Ok(upozila);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Upozila upozila)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _upozilaRepository.AddAsync(upozila);
                await _unitOfWork.CompleteAsync();
                return Ok(upozila);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Upozila upozila)
        {
            var existingUpozila = await _upozilaRepository.FindByIdAsync(id);

            if (existingUpozila == null)
                return StatusCode(500, "Upozila not found");

            existingUpozila.Name = upozila.Name;
            existingUpozila.UpozilaCode = upozila.UpozilaCode;

            try
            {
                _upozilaRepository.Update(existingUpozila);
                await _unitOfWork.CompleteAsync();
                return Ok(upozila);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingUpozila = await _upozilaRepository.FindByIdAsync(id);

            try
            {
                _upozilaRepository.Remove(existingUpozila);
                await _unitOfWork.CompleteAsync();

                return Ok(existingUpozila);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
