using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<Division>> ListAsync();
        Task<Division> FindByIdAsync(int id);
        Task AddAsync(Division division);
        void Update(Division division);
        void Remove(Division division);
    }
}
