using farmers_market_rest_api.Domain.Models.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Shop
{
    public interface IInstrumentRepository
    {
        Task<IEnumerable<Instrument>> ListAsync();
        Task<Instrument> FindByIdAsync(int id);
        Task AddAsync(Instrument instrument);
        void Update(Instrument instrument);
        void Remove(Instrument instrument);
    }
}
