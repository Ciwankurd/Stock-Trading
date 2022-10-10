using System.Collections.Generic;
using System.Threading.Tasks;
using Stock_Trading.Models;

namespace Stock_Trading.DAL
{
    public interface IstockRepository
    {
        Task<bool> LagreStock(Stock nystock);
        Task<List<Stock>> HentAlleStock();
        Task<bool> SlettStock(int id);
        Task<Stock> HentEnStock(int id);
        Task<bool> EndreStock(Stock endreStock);
        Task<bool> RegistrereNyBruker(Bruker nybruker);
        Task<int> LoggInn(Bruker bruker);
        Task<Bruker> HentEnBruker(int id);
        Task<List<BrukerStock>> HentAlleBrukerStocks(int KId);
        Task<bool> KjopeStocks(BrukerStock kjopstocks);
        Task<bool> SelgeStocks(BrukerStock selgeEnstocks);
        
    }
}
