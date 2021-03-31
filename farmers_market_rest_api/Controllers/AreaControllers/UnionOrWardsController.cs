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
    public class UnionOrWardsController : Controller
    {
        private readonly IUnionOrWardRepository _unionOrWardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UnionOrWardsController(IUnionOrWardRepository unionOrWardRepository,
                                 IUnitOfWork unitOfWork)
        {
            _unionOrWardRepository = unionOrWardRepository;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IEnumerable<UnionOrWard>> GetAllAsync()
        {
            var unionOrWards = await _unionOrWardRepository.ListAsync();

            return unionOrWards;

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var unionOrWard = await _unionOrWardRepository.FindByIdAsync(id);

            return Ok(unionOrWard);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]UnionOrWard unionOrWard)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _unionOrWardRepository.AddAsync(unionOrWard);
                await _unitOfWork.CompleteAsync();
                return Ok(unionOrWard);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UnionOrWard unionOrWard)
        {
            var existingUnionOrWard = await _unionOrWardRepository.FindByIdAsync(id);

            if (existingUnionOrWard == null)
                return StatusCode(500, "Counntry not found");

            existingUnionOrWard.Name = unionOrWard.Name;
            existingUnionOrWard.UnionOrWardCode = unionOrWard.UnionOrWardCode;

            try
            {
                _unionOrWardRepository.Update(existingUnionOrWard);
                await _unitOfWork.CompleteAsync();
                return Ok(unionOrWard);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var existingUnionOrWard = await _unionOrWardRepository.FindByIdAsync(id);

            try
            {
                _unionOrWardRepository.Remove(existingUnionOrWard);
                await _unitOfWork.CompleteAsync();

                return Ok(existingUnionOrWard);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
