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
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(_ => _.Id == id).FirstOrDefault();
        }

        public async Task<Country> FindByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public void Remove(Country country)
        {
            _context.Countries.Remove(country);
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }
    }
}
