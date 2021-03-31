namespace farmers_market_rest_api.Domain.Models.Business
{
    public class OrderDetails
    {
        public int Id { get; set; }


        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }


        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
