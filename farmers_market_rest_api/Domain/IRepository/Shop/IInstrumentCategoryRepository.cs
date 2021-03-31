using farmers_market_rest_api.Domain.Models.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Shop
{
    public interface IInstrumentCategoryRepository
    {
        Task<IEnumerable<InstrumentCategory>> ListAsync();
        Task<InstrumentCategory> FindByIdAsync(int id);
        Task AddAsync(InstrumentCategory category);
        void Update(InstrumentCategory category);
        void Remove(InstrumentCategory category);
    }
}
