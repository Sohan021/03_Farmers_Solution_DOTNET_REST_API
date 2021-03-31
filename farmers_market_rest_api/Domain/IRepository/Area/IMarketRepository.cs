using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface IMarketRepository
    {
        Task<IEnumerable<Market>> ListAsync();
        Task<Market> FindByIdAsync(int id);
        Task AddAsync(Market market);
        void Update(Market market);
        void Remove(Market market);
    }
}
