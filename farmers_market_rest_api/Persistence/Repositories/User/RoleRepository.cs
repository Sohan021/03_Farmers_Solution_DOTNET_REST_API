using farmers_market_rest_api.Domain.IRepository.User;
using farmers_market_rest_api.Domain.Models.User;
using farmers_market_rest_api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Repositories.User
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRole(ApplicationRole applicationRole)
        {
            await _context.ApplicationRoles.AddAsync(applicationRole);
        }

        public async Task<ApplicationRole> FindByIdAsync(string id)
        {
            return await _context.ApplicationRoles.FindAsync(id);
        }

        public async Task<IEnumerable<ApplicationRole>> ListOfRoles()
        {
            return await _context.ApplicationRoles.ToListAsync();
        }



        public async Task<IEnumerable<ApplicationUser>> ListOfUserInRole(string id)
        {
            return await _context.ApplicationUsers.Where(u => u.ApplicationRole.Id == id).ToListAsync();
        }

        public void RemoveRole(ApplicationRole applicationRole)
        {
            _context.ApplicationRoles.Remove(applicationRole);
        }

        public void UpdateRole(ApplicationRole applicationRole)
        {
            _context.ApplicationRoles.Update(applicationRole);
        }
    }
}
