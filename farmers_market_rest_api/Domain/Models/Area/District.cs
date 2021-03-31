namespace farmers_market_rest_api.Domain.Models.Area
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DistrictCode { get; set; }

        public int? DivisionId { get; set; }

        public virtual Division Division { get; set; }
    }
}
