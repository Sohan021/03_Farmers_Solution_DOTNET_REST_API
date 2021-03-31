using farmers_market_rest_api.Domain.IRepository.Area;
using farmers_market_rest_api.Domain.Models.Area;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Repositories.Area
{
    public class DivisionRepository : BaseRepository, IDivisionRepository
    {
        public DivisionRepository(AppDbContext context) : base(context)
        {

        }


        public async Task AddAsync(Division division)
        {
            var country = await _context.Countries.Where(_ => _.Id == 1).FirstOrDefaultAsync();

            var div = new Division
            {
                Name = division.Name,
                DivisionCode = division.DivisionCode,
                CountryId = country.Id,
                Country = country
            };

            await _context.AddAsync(div);
        }

        public async Task<Division> FindByIdAsync(int id)
        {
            return await _context.Divisions.Include(_ => _.Country).FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<Division>> ListAsync()
        {
            return await _context.Divisions.Include(_ => _.Country).ToListAsync();
        }

        public void Remove(Division division)
        {
            _context.Remove(division);
        }

        public void Update(Division division)
        {
            _context.Update(division);
        }


    }
}
