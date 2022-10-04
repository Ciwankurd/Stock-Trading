using System.Threading.Tasks;
using Stock_Trading.Models;

namespace Stock_Trading.DAL
{
    public interface IstockRepository
    {
        Task<bool> LagreStock(Stock nystock);
    }
}
