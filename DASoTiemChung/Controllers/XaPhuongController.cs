using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class XaPhuongController : Controller
    {
        private readonly ILogger<XaPhuongController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<XaPhuong> _reposity;

        public XaPhuongController(ILogger<XaPhuongController> logger, SoTiemChungContext context, IGenericRepository<XaPhuong> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteGetByHuyen = "GetByHuyen";
        [HttpGet("[controller]/GetByTinh", Name = RouteGetByHuyen)]
        public async Task<IActionResult> GetByMaHuyen(int maHuyen)
        {

            var result = _reposity.GetAll().Where(x => x.MaQuanHuyen == maHuyen).OrderBy(x=>x.TenXaPhuong).ToList();
            return Ok(result);
        }
    }
}
