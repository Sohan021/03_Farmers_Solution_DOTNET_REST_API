using farmers_market_rest_api.Domain.Models.User;
using System;
using System.Collections.Generic;

namespace farmers_market_rest_api.Domain.Models.Business
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();

        }
        public int Id { get; set; }

        public int OrderNo { get; set; }

        public string FarmerName { get; set; }

        public string HoleSellerName { get; set; }

        public DateTime OrderDate { get; set; }


        public string HoleSellerPhoneNo { get; set; }

        public double TotalAmount { get; set; }


        public string HoleSellerId { get; set; }
        public ApplicationUser Holeseller { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
