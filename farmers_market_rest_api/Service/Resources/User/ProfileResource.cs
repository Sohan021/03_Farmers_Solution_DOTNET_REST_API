using Microsoft.AspNetCore.Http;

namespace farmers_market_rest_api.Service.Resources.User
{
    public class ProfileResource
    {
        public string CurrentUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public int PostalCode { get; set; }

        public string Address { get; set; }

        public IFormFile ProfilePhotoFile { get; set; }

        public string ProfilePhoto { get; set; }
    }
}
