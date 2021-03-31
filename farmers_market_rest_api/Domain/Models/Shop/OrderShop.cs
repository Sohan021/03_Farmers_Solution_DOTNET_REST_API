using farmers_market_rest_api.Domain.Models.User;
using System;
using System.Collections.Generic;

namespace farmers_market_rest_api.Domain.Models.Shop
{
    public class OrderShop
    {
        public OrderShop()
        {
            InstrumentOrderDetails = new List<InstrumentOrderDetails>();

        }
        public int Id { get; set; }

        public int OrderNo { get; set; }

        public string UserName { get; set; }

        public DateTime OrderDate { get; set; }

        public string PhoneNo { get; set; }

        public double TotalAmount { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public virtual List<InstrumentOrderDetails> InstrumentOrderDetails { get; set; }
    }
}
