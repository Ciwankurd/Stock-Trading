using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Stock_Trading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_Trading.DAL
{
    public class StockRepository : IstockRepository
    {
        private readonly StockContext _db;

        public StockRepository(StockContext db)
        {
            _db = db;
        }

        public async Task<bool> LagreStock(Stock enstock)
        {
            try
            {               
                _db.stocks.Add(enstock);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Stock>> HentAlleStock()
        {
            try
            {
                List<Stock> alleStocks = await _db.stocks.Select(s => new Stock
                {
                    SId = s.SId,
                    SelskapNavn = s.SelskapNavn,
                    SistePrise = s.SistePrise,
                    Tegn = s.Tegn,
                    AntallStock = s.AntallStock,
                    Endring = s.Endring,
                    volume = s.volume
                }).ToListAsync();
                return alleStocks;
            }
            catch
            {
                return null;
            }


        }

        public async Task<bool> SlettStock(int id)
        {
            try
            {
                Stock slettStock = await _db.stocks.FindAsync(id);
                _db.stocks.Remove(slettStock);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public async Task<Stock> HentEnStock(int Sid)
        {
            try
            {
                Stock s = await _db.stocks.FindAsync(Sid);
                return s;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> EndreStock(Stock endreStock)
        {
            try
            {
                Stock enstock = await _db.stocks.FindAsync(endreStock.SId);

                enstock.AntallStock = endreStock.AntallStock;
                enstock.Endring = endreStock.Endring;
                enstock.SistePrise = endreStock.SistePrise;
                enstock.volume = endreStock.volume;
                enstock.SelskapNavn = endreStock.SelskapNavn;
                enstock.Tegn = endreStock.Tegn;
                _db.stocks.Update(enstock);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<int> LoggInn(Bruker bruker)
        {
            try
            {
                Bruker b = await _db.brukere.Where(B => B.brukernavn==bruker.brukernavn).FirstAsync();
                if(b != null && b.password == bruker.password)
                {
                    return b.BId;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }
        }
       public async Task<List<BrukerStock>> HentAlleBrukerStocks(int Bid )
        {
            try
            {
                List<BrukerStock> bs = await _db.brukerstock.Where(S => S.BId==Bid).ToListAsync();
                /*

                for (int i=0; i< bs.Count; i++)
                {
                    bs[i].stock = HentEnStock(bs[i].SId);
                }
                */

                return bs;
                /*
                List<BrukerStock> hentetStock = await _db.brukerstock.Select(s => new BrukerStock
                {
                    BSId = s.BSId,
                    //bruker = await _db.brukere.FindAsync(s.bruker.BId),
                    bruker = s.bruker,
                    stock = s.stock,
                    antallstock = s.antallstock,
                    DateAndTime = s.DateAndTime,

                }).ToListAsync();
                return hentetStock;
                */

            }
            catch
            {
                return null;
            }
        }


        public async Task<Bruker> HentEnBruker(int id)
        {
            try
            {
                Bruker b = await _db.brukere.FindAsync(id);
                return b;
            }
            catch
            {
                return null;
            }
        }

       

        public async Task<bool> KjopeStocks(BrukerStock BS)
        {
            try
            {

                var NyRadKjoptSB = new BrukerStock();
                NyRadKjoptSB.antallstock = BS.antallstock;
                NyRadKjoptSB.BId = BS.BId;
                NyRadKjoptSB.SId = BS.SId;
                NyRadKjoptSB.DateAndTime = DateAndTime.Now.ToString();

                var funnetstock = await _db.stocks.FindAsync(BS.SId);
                if (BS.antallstock < funnetstock.AntallStock)
                {
                    funnetstock.AntallStock = funnetstock.AntallStock - BS.antallstock;
                    _db.stocks.Update(funnetstock);

                    _db.brukerstock.Add(NyRadKjoptSB);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            


        }

        public async Task<bool> SelgeStocks(BrukerStock BS)
        {
            try
            {
                BrukerStock bs = await _db.brukerstock.FindAsync(BS.BSId);

                if (bs.antallstock == BS.antallstock)
                {
                    var funnetstock = await _db.stocks.FindAsync(bs.SId);
                    funnetstock.AntallStock = funnetstock.AntallStock + BS.antallstock;
                    _db.stocks.Update(funnetstock);
                    _db.brukerstock.Remove(bs);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else if (bs.antallstock > BS.antallstock) {

                    bs.antallstock = bs.antallstock - BS.antallstock;
                    var funnetstock = await _db.stocks.FindAsync(bs.SId);
                    funnetstock.AntallStock = funnetstock.AntallStock + BS.antallstock;
                    _db.stocks.Update(funnetstock);
                    _db.brukerstock.Update(bs);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> RegistrereNyBruker(Bruker nybruker)
        {
            try
            {

                Bruker b = new Bruker();
                b.brukernavn = nybruker.brukernavn;
                b.password = nybruker.password;
                _db.brukere.Add(b);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
