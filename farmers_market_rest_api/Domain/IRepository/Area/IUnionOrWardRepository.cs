using farmers_market_rest_api.Domain.Models.Area;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.Area
{
    public interface IUnionOrWardRepository
    {
        Task<IEnumerable<UnionOrWard>> ListAsync();
        Task<UnionOrWard> FindByIdAsync(int id);
        Task AddAsync(UnionOrWard unionOrWard);
        void Update(UnionOrWard unionOrWard);
        void Remove(UnionOrWard unionOrWard);
    }
}
