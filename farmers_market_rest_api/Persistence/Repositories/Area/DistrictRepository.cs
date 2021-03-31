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
    public class DistrictRepository : BaseRepository, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(District district)
        {
            await _context.Districts.AddAsync(district);
        }

        public async Task<District> FindByIdAsync(int id)
        {
            return await _context.Districts.Include(_ => _.Division).FirstOrDefaultAsync(_ => _.Id == id);
        }

        public District GetDistrict(int id)
        {
            return _context.Districts.Include(_ => _.Id == id).Where(_ => _.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _context.Districts.Include(_ => _.Division).ToListAsync();
        }

        public void Remove(District district)
        {
            _context.Districts.Remove(district);
        }

        public void Update(District district)
        {
            _context.Districts.Update(district);
        }
    }
}
