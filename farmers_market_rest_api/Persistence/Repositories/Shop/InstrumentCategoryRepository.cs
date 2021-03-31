using farmers_market_rest_api.Domain.IRepository.Shop;
using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Repositories.Shop
{
    public class InstrumentCategoryRepository : IInstrumentCategoryRepository
    {
        private readonly AppDbContext _context;

        public InstrumentCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InstrumentCategory category)
        {
            await _context.InstrumentCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<InstrumentCategory> FindByIdAsync(int id)
        {
            var category = await _context.InstrumentCategories.Where(_ => _.Id == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<IEnumerable<InstrumentCategory>> ListAsync()
        {
            var categories = await _context.InstrumentCategories.ToListAsync();
            return categories;
        }

        public void Remove(InstrumentCategory category)
        {
            _context.InstrumentCategories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(InstrumentCategory category)
        {
            _context.InstrumentCategories.Update(category);
            _context.SaveChanges();
        }
    }
}
