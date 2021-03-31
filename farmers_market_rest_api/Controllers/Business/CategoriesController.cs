using farmers_market_rest_api.Domain.Models.Business;
using farmers_market_rest_api.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.Business
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var category = await _context.Categories.Where(_ => _.Id == id).FirstOrDefaultAsync(_ => _.Id == id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Category category)
        {

            var cat = new Category
            {
                Name = category.Name,
                Description = category.Description
            };
            await _context.AddAsync(cat);
            await _context.SaveChangesAsync();

            return Ok(cat);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Category category)
        {

            var cat = _context.Categories.Where(_ => _.Id == id).FirstOrDefault();

            cat.Name = category.Name;
            cat.Description = category.Description;

            _context.Update(cat);
            await _context.SaveChangesAsync();

            return Ok(cat);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsycn(int id)
        {

            var cat = _context.Categories.Where(_ => _.Id == id).FirstOrDefault();

            _context.Remove(cat);
            await _context.SaveChangesAsync();

            return Ok(cat);
        }

    }
}
