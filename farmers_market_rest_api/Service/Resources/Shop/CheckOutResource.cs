using farmers_market_rest_api.Domain.Models.Shop;
using System.Collections.Generic;

namespace farmers_market_rest_api.Service.Resources.Shop
{
    public class CheckOutResource
    {
        public CheckOutResource()
        {
            Products = new List<Instrument>();
        }

        public string CurrentUserId { get; set; }

        public double Amount { get; set; }

        public virtual List<Instrument> Products { get; set; }
    }
}
