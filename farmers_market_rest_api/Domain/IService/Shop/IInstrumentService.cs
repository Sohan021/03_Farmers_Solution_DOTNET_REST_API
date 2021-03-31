using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IService.Shop
{
    public interface IInstrumentService
    {
        Task<IEnumerable<Instrument>> ListAsync();
        Task<Instrument> FindByIdAsync(int id);
        Task<SaveInstrumentResponse> SaveAsync(Instrument instrument);
        Task<SaveInstrumentResponse> UpdateAsync(int id, Instrument instrument);
        Task<SaveInstrumentResponse> DeleteAsync(int id);
    }
}
