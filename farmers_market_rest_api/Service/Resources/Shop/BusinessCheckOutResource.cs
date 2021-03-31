using farmers_market_rest_api.Domain.Models.Business;
using System.Collections.Generic;

namespace farmers_market_rest_api.Service.Resources.Shop
{
    public class BusinessCheckOutResource
    {
        public BusinessCheckOutResource()
        {
            Products = new List<Product>();
        }

        public string CurrentUserId { get; set; }

        public double Amount { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
