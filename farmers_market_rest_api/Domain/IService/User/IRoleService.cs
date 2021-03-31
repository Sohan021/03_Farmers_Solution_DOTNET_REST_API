using farmers_market_rest_api.Domain.Models.User;
using farmers_market_rest_api.Domain.Services.Communication;
using farmers_market_rest_api.Service.Resources.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Domain.IService.User
{
    public interface IRoleService
    {
        Task<IEnumerable<ApplicationRole>> ListAsync();
        Task<ApplicationRole> FindByIdAsync(string id);
        Task<SaveRoleResponse> SaveAsync(ApplicationRole applicationRole);
        Task<SaveRoleResponse> UpdateAsync(string id, RoleResource roleResource);
        Task<SaveRoleResponse> DeleteAsync(string id);
    }
}
