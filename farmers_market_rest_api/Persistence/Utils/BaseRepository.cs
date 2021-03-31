using farmers_market_rest_api.Persistence.Context;

namespace farmers_market_rest_api.Persistence.Utils
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
