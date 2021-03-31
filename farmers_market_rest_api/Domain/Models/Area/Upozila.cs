namespace farmers_market_rest_api.Domain.Models.Area
{
    public class Upozila
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UpozilaCode { get; set; }

        public int? DistrictId { get; set; }

        public virtual District District { get; set; }

    }
}
