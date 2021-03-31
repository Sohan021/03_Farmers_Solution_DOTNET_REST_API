using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> ListAsync();
        Task<District> FindByIdAsync(int id);
        Task AddAsync(District district);
        void Update(District district);
        void Remove(District district);
    }
}
