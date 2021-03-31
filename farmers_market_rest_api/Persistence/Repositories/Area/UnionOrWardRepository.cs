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
    public class UnionOrWardRepository : BaseRepository, IUnionOrWardRepository
    {
        public UnionOrWardRepository(AppDbContext context) : base(context)
        {
        }



        public async Task AddAsync(UnionOrWard union)
        {
            await _context.UnionOrWards.AddAsync(union);
        }

        public async Task<UnionOrWard> FindByIdAsync(int id)
        {
            return await _context.UnionOrWards
                        .Include(_ => _.Upozila)
                        .ThenInclude(_ => _.District)
                        .ThenInclude(_ => _.Division)
                        .Where(_ => _.Id == id)
                        .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<UnionOrWard>> ListAsync()
        {
            return await _context.UnionOrWards
                        .Include(_ => _.Upozila)
                        .ThenInclude(_ => _.District)
                        .ThenInclude(_ => _.Division)
                        .ToListAsync();
        }

        public void Remove(UnionOrWard union)
        {
            _context.UnionOrWards.Remove(union);
        }

        public void Update(UnionOrWard union)
        {
            _context.UnionOrWards.Update(union);
        }
    }
}
