using Microsoft.AspNetCore.Identity;

namespace farmers_market_rest_api.Domain.Models.User
{
    public class ApplicationRole : IdentityRole
    {
        public string RoleName { get; set; }

        public string Description { get; set; }
    }
}
