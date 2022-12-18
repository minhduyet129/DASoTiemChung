using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SoTiemChungContext _context;
        

        public HomeController(ILogger<HomeController> logger, SoTiemChungContext context)
        {
            _logger = logger;
            _context = context;
           
        }

        public IActionResult Index()
        {
            ViewBag.MuiTiemHomQua= _context.PhieuTiems.Where(x => !x.DaXoa && x.ThoiGianTiem > DateTime.Now.Date.AddDays(-1) && x.ThoiGianTiem < DateTime.Today.Date).Count();
            ViewBag.TongMuiTiem= _context.PhieuTiems.Where(x => !x.DaXoa).Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
