using farmers_market_rest_api.Domain.Models.Shop;

namespace farmers_market_rest_api.Domain.Services.Communication
{
    public class SaveInstrumentResponse : BaseResponse<Instrument>
    {
        public SaveInstrumentResponse(Instrument instrument) : base(instrument) { }

        public SaveInstrumentResponse(string message) : base(message) { }
    }
}
