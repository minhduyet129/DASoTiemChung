using DASoTiemChung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly ILogger<ThongKeController> _logger;
        private readonly SoTiemChungContext _context;


        public ThongKeController(ILogger<ThongKeController> logger, SoTiemChungContext context)
        {
            _logger = logger;
            _context = context;

        }
        public const string TiLeTiem = "TiLeTiem";
        [HttpGet("[controller]/TiLeTiem", Name = TiLeTiem)]
        public async Task<IActionResult> TiLeTiemAsync()
        {
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                            {
                            "Số mũi tiêm", "Số lượng"
                            });


            var a = _context.PhieuTiems.Where(x => !x.DaXoa).GroupBy(x => x.MaNguoiDan).Select(
                x =>
                new
                {
                    MaNguoiDan = x.Key,
                    SoLuong = x.Count()
                }

                );

            var result = a.GroupBy(x => x.SoLuong).Select(x=> new
            {
                SoMui = x.Key,
                SoLuong=x.Count()
            }).ToList();

            foreach(var item in result)
            {
                chartData.Add(new object[]
                {
                    item.SoMui.ToString()+" mũi tiêm",item.SoLuong
                });
            }
            return Ok(chartData);
        }
    }
}
