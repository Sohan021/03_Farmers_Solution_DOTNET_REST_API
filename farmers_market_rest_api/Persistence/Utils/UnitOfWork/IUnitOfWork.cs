using System.Threading.Tasks;

namespace farmers_market_rest_api.Persistence.Utils.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
