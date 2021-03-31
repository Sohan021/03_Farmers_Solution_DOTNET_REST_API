using farmers_market_rest_api.Domain.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IRepository.User
{
    public interface IRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> ListOfRoles();
        Task<IEnumerable<ApplicationUser>> ListOfUserInRole(string id);

        Task<ApplicationRole> FindByIdAsync(string id);
        Task AddRole(ApplicationRole applicationRole);
        void UpdateRole(ApplicationRole applicationRole);
        void RemoveRole(ApplicationRole applicationRole);
    }
}
