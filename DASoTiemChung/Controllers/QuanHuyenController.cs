using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class QuanHuyenController : Controller
    {
        private readonly ILogger<QuanHuyenController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<QuanHuyen> _reposity;

        public QuanHuyenController(ILogger<QuanHuyenController> logger, SoTiemChungContext context, IGenericRepository<QuanHuyen> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteGetByTinh = "GetByTinh";
        [HttpGet("[controller]/GetByTinh", Name = RouteGetByTinh)]
        public async Task<IActionResult> GetByMaTinh(int maTinh)
        { 
            
            var result=_reposity.GetAll().Where(x => x.MaTinhThanhPho == maTinh).ToList();
            return Ok(result);
        }
    }
}
