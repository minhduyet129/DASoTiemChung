using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<IActionResult> Index(TraCuuInputDto input)
        {
            
            if (!string.IsNullOrWhiteSpace(input.TenNguoiDan) && !string.IsNullOrWhiteSpace(input.SoCCCDHC))
            {
                var query =( from nguoidans in _context.NguoiDans
                               join xaphuongs in _context.XaPhuongs on nguoidans.MaXaPhuong equals xaphuongs.MaXaPhuong into kxp

                               from nguoidanxa in kxp.DefaultIfEmpty()

                               join quanhuyen in _context.QuanHuyens on nguoidanxa.MaQuanHuyen equals quanhuyen.MaQuanHuyen into kxq

                               from nguoidanxaquan in kxq.DefaultIfEmpty()

                               join tinh in _context.TinhThanhPhos on nguoidanxaquan.MaTinhThanhPho equals tinh.MaTinhThanhPho into kxqt

                               from nguoidanxaquantinh in kxqt.DefaultIfEmpty()
                               where !nguoidans.DaXoa 
                               select new ThongTinTiemChungOutputDto
                               {
                                   MaNguoiDan=nguoidans.MaNguoiDan,
                                   HoTen=nguoidans.HoTen,
                                   SoDienThoai=nguoidans.SoDienThoai,
                                   BHYT=nguoidans.SoTheBaoHiemYte,
                                   CCCD=nguoidans.SoCccdhc,
                                   NgaySinh=nguoidans.NgaySinh,
                                   DiaChi=$"{nguoidans.SoNha} {nguoidanxa.TenXaPhuong} {nguoidanxaquan.TenQuanHuyen} {nguoidanxaquantinh.TenTinhThanhPho}"
                               }).Where(x=>x.HoTen==input.TenNguoiDan&&x.CCCD==input.SoCCCDHC);
                var thongTinTraCuu = query.FirstOrDefault();

                if (thongTinTraCuu != null)
                {
                    



                    thongTinTraCuu.DanhSachPhieuTiems = _context.PhieuTiems.Include(x => x.MaVacXinTheoLoNavigation).ThenInclude(x=>x.MaVacXinNavigation)
                        .Include(x => x.MaVacXinTheoLoNavigation).ThenInclude(x => x.MaLoNavigation)

                        .Include(x => x.MaMuiTiemNavigation).Include(x => x.MaKhoNavigation).Where(x => !x.DaXoa && x.MaNguoiDan == thongTinTraCuu.MaNguoiDan).ToList();
                    ViewBag.ThongTinTraCuu = thongTinTraCuu;


                    //Tạo mã QR
                    QRCodeGenerator QrGenerator = new QRCodeGenerator();
                    QRCodeData QrCodeInfo = QrGenerator.CreateQrCode($"{Request.Scheme}://{Request.Host}{Request.PathBase}{Request.Path}{Request.QueryString}", QRCodeGenerator.ECCLevel.Q);
                    QRCode QrCode = new QRCode(QrCodeInfo);
                    Bitmap QrBitmap = QrCode.GetGraphic(60);
                    byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                    string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                    ViewBag.QrCodeUri = QrUri;
                }
                else
                {
                    TempData["Message"] = "Thông tin tiểm chủng không tồn tại";
                }

            }
            else
            {
                
                TempData["Message"] = "Vui lòng nhập thông tin người dân cần tra cứu";
            }
            return View();
        }

        
    }
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
