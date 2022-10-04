using Microsoft.AspNetCore.Mvc;
using Stock_Trading.DAL;

namespace Stock_Trading.Controllers
{
    [Route("[controller]/[action]")]
    public class StockController : ControllerBase
    {
        public readonly IstockRepository _db;
        public StockController(IstockRepository db)
        {
            _db = db;
        }
    }
}
