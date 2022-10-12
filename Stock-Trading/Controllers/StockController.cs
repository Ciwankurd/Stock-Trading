using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stock_Trading.DAL;
using Stock_Trading.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock_Trading.Controllers
{
    [Route("[controller]/[action]")]
    public class StockController : ControllerBase
    {
        public readonly IstockRepository _db;
        private ILogger<StockController> _log;
        public StockController(IstockRepository db, ILogger<StockController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<bool> lagreStock(Stock nystock)
        {
            return await _db.LagreStock(nystock);
        }


        public async Task<bool> endreStock(Stock endrestock)
        {
            return await _db.EndreStock(endrestock);
        }

        public async Task<bool> slettStock(int SId)
        {
            return await _db.SlettStock(SId);
        }


        public async Task<List<Stock>> hentAlleStocks()
        {
            return await _db.HentAlleStock();
        }

        public async Task<Stock> hentEnStock(int Sid)
        {
            return await _db.HentEnStock(Sid);
        }

        public async Task<bool> registereBruker(Bruker nybruker)
        {
            return await _db.RegistrereNyBruker(nybruker);
        }

        public async Task<int> logginn(Bruker logginn)
        {

            return await _db.LoggInn(logginn);
            
        }

        public async Task<Bruker> hentEnBruker(int BId)
        {
            Bruker bruker = await _db.HentEnBruker(BId);
            return bruker;
        }
        public async Task<bool> kjopestocks(BrukerStock kjopeNystocks)
        {
             return await _db.KjopeStocks(kjopeNystocks);
        }
        public async Task<bool> slegeStocks(BrukerStock SelgeEnStocks)
        {
            return await _db.SelgeStocks(SelgeEnStocks);
        }
        public async Task<List<BrukerStock>> HentBrukerStocks(int BId)
        {
            List<BrukerStock> alleBrukerStock = await _db.HentAlleBrukerStocks(BId);
            return alleBrukerStock;
        }
    }
}
