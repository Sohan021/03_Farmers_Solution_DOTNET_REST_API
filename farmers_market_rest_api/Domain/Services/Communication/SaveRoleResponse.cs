using farmers_market_rest_api.Domain.Models.User;

namespace farmers_market_rest_api.Domain.Services.Communication
{
    public class SaveRoleResponse : BaseResponse<ApplicationRole>
    {
        public SaveRoleResponse(ApplicationRole applicationRole) : base(applicationRole)
        { }


        public SaveRoleResponse(string message) : base(message)
        { }
    }
}
