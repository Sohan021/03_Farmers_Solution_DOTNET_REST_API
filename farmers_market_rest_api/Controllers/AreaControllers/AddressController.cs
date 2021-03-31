using farmers_market_rest_api.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.AreaControllers
{
    [Route("/api/[controller]/[action]")]
    public class AddressController : Controller
    {
        private readonly AppDbContext _context;

        public AddressController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetAreaCode()
        {
            var area = await _context.ApplicationUsers
                                //.Where(_ => _.ApplicationRole.Name == "Farmer")
                                .Include(_ => _.Market)
                                .ThenInclude(_ => _.UnionOrWard)
                                .ThenInclude(_ => _.Upozila)
                                .ThenInclude(_ => _.District)
                                .ThenInclude(_ => _.Division)
                                .ThenInclude(_ => _.Country)
                                .ToListAsync();
            return Ok(area);
        }



    }
}
