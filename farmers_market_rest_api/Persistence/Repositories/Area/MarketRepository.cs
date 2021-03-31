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
    public class MarketRepository : BaseRepository, IMarketRepository
    {
        public MarketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Market market)
        {
            await _context.Markets.AddAsync(market);
        }

        public Market GetMarket(int id)
        {
            return _context.Markets.Where(_ => _.Id == id).FirstOrDefault();
        }

        public async Task<Market> FindByIdAsync(int id)
        {
            return await _context.Markets.Include(_ => _.UnionOrWard).FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<Market>> ListAsync()
        {
            return await _context.Markets.Include(_ => _.UnionOrWard).ToListAsync();
        }

        public void Remove(Market market)
        {
            _context.Markets.Remove(market);
        }

        public void Update(Market market)
        {
            _context.Markets.Update(market);
        }
    }
}
