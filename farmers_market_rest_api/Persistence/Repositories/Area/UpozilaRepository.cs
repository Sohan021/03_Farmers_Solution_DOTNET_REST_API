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
    public class UpozilaRepository : BaseRepository, IUpozilaRepository
    {
        public UpozilaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(Upozila upozilla)
        {
            await _context.Upozillas.AddAsync(upozilla);
        }

        public async Task<Upozila> FindByIdAsync(int id)
        {
            return await _context.Upozillas
                        .Include(_ => _.District)
                        .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public Upozila GetUpozilla(int id)
        {
            return _context.Upozillas
                   .Where(_ => _.Id == id)
                   .FirstOrDefault();
        }

        public async Task<IEnumerable<Upozila>> ListAsync()
        {
            return await _context.Upozillas
                        .Include(_ => _.District)
                        .ToListAsync();
        }

        public void Remove(Upozila upozilla)
        {
            _context.Upozillas.Remove(upozilla);
        }

        public void Update(Upozila upozilla)
        {
            _context.Upozillas.Update(upozilla);
        }
    }
}
