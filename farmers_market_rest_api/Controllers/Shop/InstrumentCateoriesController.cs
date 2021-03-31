using farmers_market_rest_api.Domain.IRepository.Shop;
using farmers_market_rest_api.Domain.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.Shop
{
    [Route("api/[controller]")]
    public class InstrumentCateoriesController : Controller
    {
        private readonly IInstrumentCategoryRepository _categoryRepository;

        public InstrumentCateoriesController(IInstrumentCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<InstrumentCategory>> GetAllAsync()
        {

            var categories = await _categoryRepository.ListAsync();

            return categories;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] InstrumentCategory category)
        {

            await _categoryRepository.AddAsync(category);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] InstrumentCategory resource)
        {

            var category = await _categoryRepository.FindByIdAsync(id);

            category.Name = resource.Name;
            category.Description = resource.Description;


            _categoryRepository.Update(category);



            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);

            _categoryRepository.Remove(category);

            return Ok();
        }
    }
}
