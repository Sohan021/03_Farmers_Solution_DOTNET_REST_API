using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<Country> FindByIdAsync(int id);
        Task AddAsync(Country country);
        void Update(Country country);
        void Remove(Country country);
    }
}
