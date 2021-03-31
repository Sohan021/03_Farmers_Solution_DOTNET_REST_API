namespace farmers_market_rest_api.Domain.Models.Shop
{
    public class InstrumentOrderDetails
    {
        public int Id { get; set; }


        public int? OrderShopId { get; set; }
        public virtual OrderShop OrderShop { get; set; }


        public int? InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }

    }
}
