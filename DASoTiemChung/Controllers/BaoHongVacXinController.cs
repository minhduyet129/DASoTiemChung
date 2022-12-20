using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    [Authorize(Roles =Quyens.BaoHong)]
    public class BaoHongVacXinController : Controller
    {
        private readonly ILogger<BaoHongVacXinController> _logger;
        private readonly SoTiemChungContext _context;


        public BaoHongVacXinController(ILogger<BaoHongVacXinController> logger, SoTiemChungContext context)
        {
            _logger = logger;
            _context = context;
           
        }
        public const string RouteIndex = "BaoHongHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "BaoHongGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchBaoHongDto input)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUser = _context.NhanViens.Include(x => x.MaQuyenNavigation).FirstOrDefault(x => x.TenTaiKhoan == userName);
                if (currentUser != null)
                {
                    return PartialView("_DataGrid", await GetPagingLos(input, currentUser));
                }
                else
                {
                    return BadRequest("Bạn cần đăng nhập lại để xác nhận lại người dùng!");
                }
            }
            else
            {
                return BadRequest("Bạn cần đăng nhập lại để xác nhận lại người dùng!");
            }
        }

        private async Task<PagedResultDto<ThongKeVacXinTaiDiemTiem>> GetPagingLos(SearchBaoHongDto input, NhanVien currentUser)
        {

            if (input.SkipCount < 0)
            {
                input.SkipCount = 0;
            }
            if (input.MaxResultCount <= 0)
            {
                input.MaxResultCount = 10;
            }
            int skipRecord = (input.SkipCount - 1) * input.MaxResultCount;
            var take = input.MaxResultCount;
            var query = _context.ThongKeVacXinTaiDiemTiems.Include(x => x.MaKhoNavigation).Include(x => x.MaVacXinTheoLoNavigation).AsQueryable();
            try
            {
                if (!string.IsNullOrEmpty(input.TenKho))
                {
                    query = query.Where(x => x.MaKhoNavigation.TenKho.ToLower().Contains(input.TenKho.ToLower()));
                }
                if (!string.IsNullOrEmpty(input.TenVacXin))
                {
                    query = query.Where(x => x.MaVacXinTheoLoNavigation.TenVacXinTheoLo.ToLower().Contains(input.TenVacXin.ToLower()));
                }
                if (input.NgayThongKe.HasValue)
                {
                    query = query.Where(x => x.NgayThongKe.Value.Date==input.NgayThongKe.Value.Date);
                }

                if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.NhanVienCapCao))
                {
                    query = query.Where(x => x.MaKho == currentUser.MaKho);
                }

            }
            

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<ThongKeVacXinTaiDiemTiem> result = new PagedResultDto<ThongKeVacXinTaiDiemTiem>(0, input.SkipCount, take, new List<ThongKeVacXinTaiDiemTiem>());
            result.TotalCount = query.Count();
            query = query.OrderByDescending(x => x.MaThongKe).ThenBy(x=>x.MaKhoNavigation.TenKho).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "BaoHongGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            ThongKeVacXinTaiDiemTiem result = new ThongKeVacXinTaiDiemTiem();
            


            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUser = _context.NhanViens.Include(x => x.MaQuyenNavigation).FirstOrDefault(x => x.TenTaiKhoan == userName);
                if (currentUser != null)
                {

                    if (id == 0)
                    {
                        if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.NhanVienCapCao) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho))
                        {
                            result.MaKho = currentUser.MaKho;
                            var currentKho = _context.Khos.Find(result.MaKho);
                            ViewBag.DiemTiems = new List<Kho>() { currentKho };
                            ViewBag.VacXins = _context.VacXinTheoLos.Where(x => !x.DaXoa && x.MaKho == currentUser.MaKho).OrderBy(x => x.TenVacXinTheoLo).ToList();
                        }
                        if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.QuanLy))
                        {
                            ViewBag.DiemTiems = _context.Khos.Where(x => !x.DaXoa && x.Kieu).OrderBy(x => x.TenKho).ToList();
                            
                            ViewBag.VacXins = new List<VacXinTheoLo>();


                        }
                        result.NgayThongKe = DateTime.Now;
                        return PartialView("_Form", result);
                    }

                    try
                    {
                        result = _context.ThongKeVacXinTaiDiemTiems.Include(x => x.MaKhoNavigation).Include(x => x.MaVacXinTheoLoNavigation).FirstOrDefault(x => x.MaThongKe == id);

                        if (result != null)
                        {
                            if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.NhanVienCapCao) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho))
                            {


                                var currentKho = _context.Khos.Find(result.MaKho);
                                ViewBag.DiemTiems = new List<Kho>() { currentKho };
                                ViewBag.VacXins = _context.VacXinTheoLos.Where(x => !x.DaXoa && x.MaKho == currentUser.MaKho).OrderBy(x => x.TenVacXinTheoLo).ToList();

                            }
                            if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.QuanLy))
                            {

                                ViewBag.DiemTiems = _context.Khos.Where(x => !x.DaXoa && x.Kieu).OrderBy(x => x.TenKho).ToList();

                                ViewBag.VacXins = new List<VacXinTheoLo>();

                            }

                            return PartialView("_Form", result);
                        }
                        else
                        {
                            return BadRequest("Thống kê không tồn tại!.");
                        }


                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.ToString());
                    }


                }
                else
                {
                    return BadRequest("Bạn cần đăng nhập lại để xác nhận lại người dùng!");
                }
            }
            else
            {
                return BadRequest("Bạn cần đăng nhập lại để xác nhận lại người dùng!");
            }


            return PartialView("_Form", result);
        }

        public const string RouteCreate = "BaoHongPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(ThongKeVacXinTaiDiemTiem dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var vacXinTheoLoTrongThongKe= _context.VacXinTheoLos.FirstOrDefault(x => x.MaVacXinTheoLo == dto.MaVacXinTheoLo);
                    if (vacXinTheoLoTrongThongKe.SoLuong < dto.SoLuongHong)
                    {
                        return BadRequest("Số lượng tồn kho ít hơn số lượng hỏng!");
                    }
                    else
                    {
                        dto.SoLuongTrongKho = vacXinTheoLoTrongThongKe.SoLuong;
                        vacXinTheoLoTrongThongKe.SoLuong -= dto.SoLuongHong;
                        _context.VacXinTheoLos.Update(vacXinTheoLoTrongThongKe);
                    }
                    dto.SoLuongThucTe = dto.SoLuongTrongKho - dto.SoLuongHong;
                    
                    
                    
                    _context.ThongKeVacXinTaiDiemTiems.Add(dto);
                    _context.SaveChanges();


                    transaction.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, ex.ToString());
                }
            }



            return BadRequest("Có lỗi khi xử lý!");

        }

        public const string RouteUpdate = "BaHongPutUpdate";
       
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, ThongKeVacXinTaiDiemTiem dto)
        {

            if (id != dto.MaThongKe)
            {
                return BadRequest("Lỗi request!");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {

                    
                    var thongke = _context.ThongKeVacXinTaiDiemTiems.Find(id);
                    if (thongke != null)
                    {
                        var vacXinTheoLoTrongThongKe = _context.VacXinTheoLos.FirstOrDefault(x => x.MaVacXinTheoLo == dto.MaVacXinTheoLo);
                        if (vacXinTheoLoTrongThongKe.SoLuong < dto.SoLuongHong)
                        {

                            return BadRequest("Số lượng tồn kho ít hơn số lượng hỏng!");
                        }
                        else
                        {
                            dto.SoLuongTrongKho = vacXinTheoLoTrongThongKe.SoLuong;
                            dto.SoLuongThucTe = dto.SoLuongTrongKho - dto.SoLuongHong;
                            vacXinTheoLoTrongThongKe.SoLuong -= dto.SoLuongHong;
                            _context.VacXinTheoLos.Update(vacXinTheoLoTrongThongKe);
                            _context.SaveChanges();
                        }

                        var oldVacXinTheoLo= _context.VacXinTheoLos.FirstOrDefault(x => x.MaVacXinTheoLo == thongke.MaVacXinTheoLo);
                        if (oldVacXinTheoLo != null)
                        {
                            oldVacXinTheoLo.SoLuong += thongke.SoLuongHong;
                            _context.VacXinTheoLos.Update(oldVacXinTheoLo);
                            _context.SaveChanges();
                        }

                        
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok();
                    }
                    else
                    {
                        return NotFound("Không tìm thấy thống kê cần sửa!");
                    }


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, ex.ToString());
                }
            }


            return BadRequest("Có lỗi khi xử lý!");
        }

        public const string RouteDelete = "BaoHongDelete";
        
        [HttpDelete("[controller]/{id}", Name = RouteDelete)]
        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id.HasValue)
                {
                    var lo = _context.ThongKeVacXinTaiDiemTiems.Find(id.Value);
                    if (lo != null)
                    {
                        var oldVacXinTheoLo = _context.VacXinTheoLos.FirstOrDefault(x => x.MaVacXinTheoLo == lo.MaVacXinTheoLo);
                        if (oldVacXinTheoLo != null)
                        {
                            oldVacXinTheoLo.SoLuong += lo.SoLuongHong;
                            _context.VacXinTheoLos.Update(oldVacXinTheoLo);
                           
                        }

                        _context.ThongKeVacXinTaiDiemTiems.Remove(lo);
                        _context.SaveChanges();

                        return Ok();

                    }
                    else
                    {
                        return NotFound($"Không tìm thấy bản ghi thống kê ");
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }


            return BadRequest("Có lỗi xảy ra!");

        }

        [HttpGet("[controller]/Export")]
        public IActionResult ExportToExcel()
        {
            var query = _context.ThongKeVacXinTaiDiemTiems.Include(x => x.MaKhoNavigation).Include(x => x.MaVacXinTheoLoNavigation).AsQueryable();
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUser = _context.NhanViens.Include(x => x.MaQuyenNavigation).FirstOrDefault(x => x.TenTaiKhoan == userName);
                if (currentUser != null)
                {
                    if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.NhanVienCapCao))
                    {
                        query = query.Where(x => x.MaKho == currentUser.MaKho);
                    }
                    query = query.OrderBy(x => x.MaKhoNavigation.TenKho).ThenBy(x => x.MaVacXinTheoLoNavigation.TenVacXinTheoLo);
                }
            }
            var doctors = query.ToList();
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("ThongKeVacXin");
            Sheet.Cells["A1"].Value = "Tên vắc xin theo lô";
            Sheet.Cells["B1"].Value = "Số lượng trong kho";
            Sheet.Cells["C1"].Value = "Số lượng hỏng";
            Sheet.Cells["D1"].Value = "Số lượng thực tế";
            Sheet.Cells["E1"].Value = "Ngày thống kê";
            Sheet.Cells["F1"].Value = "Địa điểm";
         
            int row = 2;
            foreach (var item in doctors)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.MaVacXinTheoLoNavigation.TenVacXinTheoLo;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.SoLuongTrongKho;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.SoLuongHong;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.SoLuongThucTe;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.NgayThongKe.Value.ToString("dd/MM/yyyy");
                Sheet.Cells[string.Format("F{0}", row)].Value = item.MaKhoNavigation.TenKho;
               
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            fileContents = Ep.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Danh sách thống kê sử dụng vắc xin.xlsx"
            );
        }
    }
}
