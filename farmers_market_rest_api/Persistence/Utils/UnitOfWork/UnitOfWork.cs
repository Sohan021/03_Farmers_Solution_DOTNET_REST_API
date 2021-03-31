using farmers_market_rest_api.Persistence.Context;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Utils.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
