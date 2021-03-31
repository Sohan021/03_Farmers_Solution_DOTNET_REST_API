using farmers_market_rest_api.Domain.Models.Area;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace farmers_market_rest_api.Domain.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string ProfilePhoto { get; set; }



        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        public int FarmerCode { get; set; }

        public int HoleSellerCode { get; set; }

        public string RoleName { get; set; }

        public string ApplicationRoleId { get; set; }

        public virtual ApplicationRole ApplicationRole { get; set; }




        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public string CountryName { get; set; }


        public int? DivisionId { get; set; }

        public Division Division { get; set; }

        public string DivisionName { get; set; }



        public int? DistrictId { get; set; }

        public District District { get; set; }

        public string DistrictName { get; set; }



        public int? UpozilaId { get; set; }

        public Upozila Upozilla { get; set; }

        public string UpozilaName { get; set; }



        public int? UnionOrWardId { get; set; }

        public UnionOrWard UnionOrWard { get; set; }

        public string UnionOrWardName { get; set; }



        public int? MarketId { get; set; }

        public Market Market { get; set; }

        public string MarketName { get; set; }

        public string MarketCode { get; set; }
    }
}
