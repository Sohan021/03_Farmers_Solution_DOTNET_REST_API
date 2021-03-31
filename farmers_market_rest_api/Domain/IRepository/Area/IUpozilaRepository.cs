using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface IUpozilaRepository
    {
        Task<IEnumerable<Upozila>> ListAsync();
        Task<Upozila> FindByIdAsync(int id);
        Task AddAsync(Upozila upozilla);
        void Update(Upozila upozilla);
        void Remove(Upozila upozilla);
    }
}
