using farmers_market_rest_api.Domain.Models.Shop;
using Microsoft.AspNetCore.Http;
using System;

namespace farmers_market_rest_api.Service.Resources.Shop
{
    public class InstrumentResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public IFormFile File { get; set; }

        public string ImageUrl1 { get; set; }

        public string ImageUrl2 { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? InstrumentCategoryId { get; set; }

        public virtual InstrumentCategory InstrumentCategory { get; set; }


    }
}
