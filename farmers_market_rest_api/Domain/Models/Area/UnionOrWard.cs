namespace farmers_market_rest_api.Domain.Models.Area
{
    public class UnionOrWard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UnionOrWardCode { get; set; }

        public int? UpozilaId { get; set; }

        public virtual Upozila Upozila { get; set; }
    }
}
