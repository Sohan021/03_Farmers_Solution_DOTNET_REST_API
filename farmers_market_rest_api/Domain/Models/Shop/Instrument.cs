using System;
using System.Collections.Generic;

namespace farmers_market_rest_api.Domain.Models.Shop
{
    public class Instrument
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl1 { get; set; }

        public string ImageUrl2 { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? InstrumentCategoryId { get; set; }

        public virtual InstrumentCategory InstrumentCategory { get; set; }

        public virtual List<InstrumentOrderDetails> OrderDetails { get; set; }
    }
}
