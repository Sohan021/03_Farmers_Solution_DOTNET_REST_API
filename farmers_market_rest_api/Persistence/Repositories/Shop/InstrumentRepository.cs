using farmers_market_rest_api.Domain.IRepository.Shop;
using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Repositories.Shop
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly AppDbContext _context;

        public InstrumentRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Instrument>> ListAsync()
        {
            return await _context.Instruments
                        .Include(_ => _.InstrumentCategory)
                        .ToListAsync();

        }
        public async Task<Instrument> FindByIdAsync(int id)
        {
            return await _context.Instruments
                        .Include(_ => _.InstrumentCategory)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Instrument instrument)
        {
            await _context.Instruments.AddAsync(instrument);

        }
        public void Update(Instrument instrument)
        {
            _context.Instruments.Update(instrument);

        }
        public void Remove(Instrument instrument)
        {
            _context.Instruments.Remove(instrument);

        }
    }
}
