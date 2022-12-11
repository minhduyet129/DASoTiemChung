using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class TraCuuTiemChungController : Controller
    {
        private readonly ILogger<TraCuuTiemChungController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<PhieuTiem> _reposity;

        public TraCuuTiemChungController(ILogger<TraCuuTiemChungController> logger, SoTiemChungContext context, IGenericRepository<PhieuTiem> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "TraCuuTiemChungHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index(string TenNguoiDan, string SoCCCDHC)
        {
            
            if (!string.IsNullOrWhiteSpace(TenNguoiDan) && !string.IsNullOrWhiteSpace(SoCCCDHC))
            {
                var thongTinTraCuu =( from nguoidans in _context.NguoiDans
                               join xaphuongs in _context.XaPhuongs on nguoidans.MaXaPhuong equals xaphuongs.MaXaPhuong into kxp

                               from nguoidanxa in kxp.DefaultIfEmpty()

                               join quanhuyen in _context.QuanHuyens on nguoidanxa.MaQuanHuyen equals quanhuyen.MaQuanHuyen into kxq

                               from nguoidanxaquan in kxq.DefaultIfEmpty()

                               join tinh in _context.TinhThanhPhos on nguoidanxaquan.MaTinhThanhPho equals tinh.MaTinhThanhPho into kxqt

                               from nguoidanxaquantinh in kxqt.DefaultIfEmpty()
                               where !nguoidans.DaXoa
                               select new ThongTinTiemChungOutputDto
                               {
                                   HoTen=nguoidans.HoTen,
                                   SoDienThoai=nguoidans.SoDienThoai,
                                   BHYT=nguoidans.SoTheBaoHiemYte,
                                   CCCD=nguoidans.SoCccdhc,
                                   NgaySinh=nguoidans.NgaySinh,
                                   DiaChi=$"{nguoidans.SoNha} {nguoidanxa.TenXaPhuong} {nguoidanxaquan.TenQuanHuyen} {nguoidanxaquantinh.TenTinhThanhPho}"
                               }).FirstOrDefault();


                if (thongTinTraCuu == null)
                {
                    TempData["Message"] = "Thông tin tiểm chủng không tồn tại";
                }
                else
                {
                    ViewBag.ThongTinTraCuu = thongTinTraCuu;
                }
            }
            else
            {
                
                TempData["Message"] = "Vui lòng nhập thông tin người dân cần tra cứu";
            }
            return View();
        }

        
    }
}
