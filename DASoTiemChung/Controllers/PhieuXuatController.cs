using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class PhieuXuatController : Controller
    {
        private readonly ILogger<PhieuXuatController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<PhieuXuat> _reposity;

        public PhieuXuatController(ILogger<PhieuXuatController> logger, SoTiemChungContext context, IGenericRepository<PhieuXuat> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "PhieuXuatHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "PhieuXuatGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchPhieuXuatDto input)
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

        private async Task<PagedResultDto<PhieuXuat>> GetPagingLos(SearchPhieuXuatDto input, NhanVien currentUser)
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
            var query = _context.PhieuXuats.Include(x => x.MaNhanVienNavigation).Include(x=>x.MaKhoNhanNavigation).Include(x=>x.MaKhoXuatNavigation).Where(x=>!x.DaXoa).AsQueryable();

            try
            {
                if (!string.IsNullOrEmpty(input.MaPhieuXuat))
                {
                    query = query.Where(x => x.MaPhieuXuat.ToString().Contains(input.MaPhieuXuat.ToString()));
                }
                if (!string.IsNullOrEmpty(input.TenNhanVien))
                {
                    query = query.Where(x => x.MaNhanVienNavigation.TenNhanVien.Contains(input.TenNhanVien));
                }
                if (!string.IsNullOrEmpty(input.TenDiemNhan))
                {
                    query = query.Where(x=>x.MaKhoNhanNavigation.TenKho.Contains(input.TenDiemNhan));
                }
                if (!string.IsNullOrEmpty(input.TenDiemXuat))
                {
                    query = query.Where(x=>x.MaKhoXuatNavigation.TenKho.Contains(input.TenDiemXuat));
                }

                if (input.ThoiGianXuat.HasValue)
                {
                    query = query.Where(x => x.ThoiGianXuat.Equals(input.ThoiGianXuat));
                }

                if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.ThuKho))
                {
                    query = query.Where(x => x.MaKhoXuat == currentUser.MaKho);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<PhieuXuat> result = new PagedResultDto<PhieuXuat>(0, input.SkipCount, take, new List<PhieuXuat>());
            result.TotalCount = query.Count();
            query = query.OrderByDescending(x => x.MaPhieuXuat).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "PhieuXuatGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            PhieuXuat result = new PhieuXuat();
            ViewBag.DiemTiems = _context.Khos.OrderBy(x => x.TenKho).Where(x => !x.DaXoa && x.Kieu).ToList();
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUser = _context.NhanViens.Include(x => x.MaQuyenNavigation).FirstOrDefault(x => x.TenTaiKhoan == userName);
                if (currentUser != null)
                {

                    if (id == 0)
                    {
                        if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.ThuKho) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho))
                        {
                            result.MaKhoXuat = currentUser.MaKho;
                            var currentKho = _context.Khos.Find(result.MaKhoXuat);
                            ViewBag.Khos = new List<Kho>() { currentKho };
                            result.MaNhanVien = currentUser.MaNhanVien;
                            ViewBag.NhanViens = new List<NhanVien>() { currentUser };
                        }
                        if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.QuanLy))
                        {
                            ViewBag.Khos = _context.Khos.Where(x => !x.DaXoa && !x.Kieu).OrderBy(x => x.TenKho).ToList();
                            ViewBag.NhanViens = new List<NhanVien>();


                        }
                        
                        result.ThoiGianXuat = DateTime.Now;
                        return PartialView("_Form", result);
                    }

                    try
                    {
                        result = _context.PhieuXuats.Include(x => x.MaNhanVienNavigation).Include(x => x.ChiTietPhieuXuats).ThenInclude(x => x.MaVacXinTheoLoNavigation).FirstOrDefault(x => x.MaPhieuXuat == id);

                        if (result != null)
                        {
                            if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.TruongKho) || currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.ThuKho))
                            {
                                var userInPhieuNhap = _context.NhanViens.Find(result.MaNhanVien);

                                if (!userInPhieuNhap.Equals(currentUser))
                                {
                                    if (userInPhieuNhap.MaKho == currentUser.MaKho)
                                    {
                                        ViewBag.NhanViens = new List<NhanVien>() { currentUser, userInPhieuNhap };
                                    }
                                    else
                                    {
                                        ViewBag.NhanViens = new List<NhanVien>() { userInPhieuNhap };
                                    }

                                }
                                else
                                {
                                    ViewBag.NhanViens = new List<NhanVien>() { userInPhieuNhap };
                                }
                                var khoInPhieuXuat = _context.Khos.Find(result.MaKhoXuat);
                                
                                ViewBag.Khos = new List<Kho>() { khoInPhieuXuat };
                            }
                            if (currentUser.MaQuyenNavigation.TenQuyen.Equals(Quyens.QuanLy))
                            {

                                //chỉ cho phép thay đổi nhân viên và thông số phiếu xuất , không cho phép thay đổi kho xuất
                                var currentKho = _context.Khos.Find(result.MaKhoXuat);
                                ViewBag.Khos = new List<Kho>() { currentKho };
                                ViewBag.NhanViens = _context.NhanViens.OrderBy(x => x.TenNhanVien).Where(x => !x.DaXoa && x.MaKho == result.MaKhoXuat).ToList();

                            }

                            return PartialView("_Form", result);
                        }
                        else
                        {
                            return BadRequest("Phiếu xuất không tồn tại!.");
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

        public const string RouteCreate = "PhieuXuatPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(PhieuXuat dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {

                    _reposity.Insert(dto);
                    _reposity.Save();
                    foreach (var ctpn in dto.ChiTietPhieuXuats)
                    {

                        ctpn.MaPhieuXuat = dto.MaPhieuXuat;
                        var vacXinTheoLo = _context.VacXinTheoLos.Include(x=>x.MaNhaSanXuatNavigation).Include(x=>x.MaLoNavigation).Include(x=>x.MaVacXinNavigation).FirstOrDefault(x=>x.MaVacXinTheoLo==ctpn.MaVacXinTheoLo);
                        if (vacXinTheoLo != null)
                        {
                            if (vacXinTheoLo.SoLuong < ctpn.SoLuong)
                                return BadRequest($"vắc xin {vacXinTheoLo.TenVacXinTheoLo} tại kho không đủ rồi.Số lượng còn lại {vacXinTheoLo.SoLuong}");
                            vacXinTheoLo.SoLuong -= ctpn.SoLuong;
                            
                            _context.Update(vacXinTheoLo);


                            var vacXinTheoLoDiemTiem= _context.VacXinTheoLos.FirstOrDefault(x => x.MaLo == vacXinTheoLo.MaLo && x.MaVacXin == vacXinTheoLo.MaVacXin && x.MaKho == dto.MaKhoNhan&&x.MaNhaSanXuat==vacXinTheoLo.MaNhaSanXuat);

                            if (vacXinTheoLoDiemTiem != null)
                            {
                                vacXinTheoLoDiemTiem.SoLuong += ctpn.SoLuong;
                                _context.VacXinTheoLos.Update(vacXinTheoLoDiemTiem);
                            }
                            else
                            {
                                var diemTiem = _context.Khos.Find(dto.MaKhoNhan);
                                var vacXinTheoLoNew = new VacXinTheoLo()
                                {
                                    MaLo = vacXinTheoLo.MaLo,
                                    MaNhaSanXuat = vacXinTheoLo.MaNhaSanXuat,
                                    MaKho = dto.MaKhoNhan,
                                    MaVacXin = vacXinTheoLo.MaVacXin,
                                    NgayHetHan = vacXinTheoLo.NgayHetHan,
                                    NgaySanXuat = vacXinTheoLo.NgaySanXuat,
                                    XuatXu = vacXinTheoLo.XuatXu,
                                    SoLuong = ctpn.SoLuong,
                                    TenVacXinTheoLo = $"{vacXinTheoLo.MaVacXinNavigation.TenVacXin}-{vacXinTheoLo.MaLoNavigation.TenLo}-{vacXinTheoLo.MaNhaSanXuatNavigation.TenNhaSanXuat}-{diemTiem.TenKho}"


                                };
                                _context.VacXinTheoLos.Add(vacXinTheoLoNew);
                            }
                        }
                        else
                        {
                            transaction.Rollback();
                            return BadRequest($"Không tìm thấy vắc xin theo lô {ctpn.MaVacXinTheoLo} cần nhập");
                        }


                    }

                    await _context.SaveChangesAsync();
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
        public const string RouteUpdate = "PhieuXuatPutUpdate";
        [Authorize(Roles = Quyens.ChinhSuaKho)]
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, PhieuXuat dto)
        {

            if (id != dto.MaPhieuXuat)
            {
                return BadRequest("Lỗi request!");
            }


            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    var lo = _reposity.GetById(id);
                    if (lo != null)
                    {
                        
                        lo.GhiChu = dto.GhiChu;
                        lo.MaNhanVien = dto.MaNhanVien;
                        lo.MaKhoNhan = dto.MaKhoNhan;
                        lo.ThoiGianXuat = dto.ThoiGianXuat;
                        lo.MaKhoXuat = dto.MaKhoXuat;

                        var childrens = dto.ChiTietPhieuXuats;
                        dto.ChiTietPhieuXuats = null;
                        _reposity.Update(lo);
                        _reposity.Save();

                        var detaillist = _context.ChiTietPhieuXuats.Where(x => x.MaPhieuXuat == dto.MaPhieuXuat).ToList();
                        foreach (var giam in detaillist)
                        {


                            var vacXinTheoLo = _context.VacXinTheoLos.Find(giam.MaVacXinTheoLo);
                            if (vacXinTheoLo != null)
                            {
                                vacXinTheoLo.SoLuong += giam.SoLuong;
                                _context.Update(vacXinTheoLo);
                            }


                        }
                        _context.ChiTietPhieuXuats.RemoveRange(detaillist);
                        _context.SaveChanges();
                        foreach (var ctpn in childrens)
                        {
                            ctpn.MaPhieuXuat = dto.MaPhieuXuat;
                            var vacXinTheoLo = _context.VacXinTheoLos.Include(x => x.MaNhaSanXuatNavigation).Include(x => x.MaLoNavigation).Include(x => x.MaVacXinNavigation).FirstOrDefault(x => x.MaVacXinTheoLo == ctpn.MaVacXinTheoLo);
                            if (vacXinTheoLo != null)
                            {
                                if (vacXinTheoLo.SoLuong < ctpn.SoLuong)
                                    return BadRequest($"vắc xin {vacXinTheoLo.TenVacXinTheoLo} tại kho không đủ rồi.Số lượng còn lại {vacXinTheoLo.SoLuong}");
                                vacXinTheoLo.SoLuong -= ctpn.SoLuong;

                                _context.Entry<VacXinTheoLo>(vacXinTheoLo).State = EntityState.Detached;


                                var vacXinTheoLoDiemTiem = _context.VacXinTheoLos.FirstOrDefault(x => x.MaLo == vacXinTheoLo.MaLo && x.MaVacXin == vacXinTheoLo.MaVacXin && x.MaKho == dto.MaKhoNhan && x.MaNhaSanXuat == vacXinTheoLo.MaNhaSanXuat);

                                if (vacXinTheoLoDiemTiem != null)
                                {
                                    vacXinTheoLoDiemTiem.SoLuong += ctpn.SoLuong;
                                    _context.VacXinTheoLos.Update(vacXinTheoLoDiemTiem);
                                }
                                else
                                {
                                    var diemTiem = _context.Khos.Find(dto.MaKhoNhan);
                                    var vacXinTheoLoNew = new VacXinTheoLo()
                                    {
                                        MaLo = vacXinTheoLo.MaLo,
                                        MaNhaSanXuat = vacXinTheoLo.MaNhaSanXuat,
                                        MaKho = dto.MaKhoNhan,
                                        MaVacXin = vacXinTheoLo.MaVacXin,
                                        NgayHetHan = vacXinTheoLo.NgayHetHan,
                                        NgaySanXuat = vacXinTheoLo.NgaySanXuat,
                                        XuatXu = vacXinTheoLo.XuatXu,
                                        SoLuong = ctpn.SoLuong,
                                        TenVacXinTheoLo = $"{vacXinTheoLo.MaVacXinNavigation.TenVacXin}-{vacXinTheoLo.MaLoNavigation.TenLo}-{vacXinTheoLo.MaNhaSanXuatNavigation.TenNhaSanXuat}-{diemTiem.TenKho}"


                                    };
                                    _context.VacXinTheoLos.Add(vacXinTheoLoNew);
                                }

                            }
                            else
                            {
                                transaction.Rollback();
                                return BadRequest($"Không tìm thấy vắc xin theo lô có mã {ctpn.MaVacXinTheoLo} cần nhập");
                            }
                            _context.ChiTietPhieuXuats.Add(ctpn);

                        }
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok();
                    }
                    return NotFound("Không tìm thấy phiếu xuất!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, ex.ToString());
                }
            }



            return BadRequest("Có lỗi khi xử lý!");
        }

        public const string RouteDelete = "PhieuXuatDelete";
        [Authorize(Roles = Quyens.ChinhSuaKho)]
        [HttpDelete("[controller]/{id}", Name = RouteDelete)]
        public async Task<IActionResult> Delete(int? id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (id.HasValue)
                    {
                        var lo = _reposity.GetById(id.Value);
                        if (lo != null)
                        {
                            var detaillist = _context.ChiTietPhieuXuats.Where(x => x.MaPhieuXuat == lo.MaPhieuXuat).ToList();
                            foreach (var detail in detaillist)
                            {
                                var vctl = _context.VacXinTheoLos.Find(detail.MaVacXinTheoLo);
                                vctl.SoLuong += detail.SoLuong;
                                _context.Update(vctl);

                                var vxtlDiemTiem = _context.VacXinTheoLos.FirstOrDefault(x => x.MaVacXin == vctl.MaVacXin && x.MaKho == lo.MaKhoNhan && x.MaLo == vctl.MaLo && x.MaNhaSanXuat == vctl.MaNhaSanXuat);
                                if (vxtlDiemTiem != null)
                                {
                                    vxtlDiemTiem.SoLuong -= detail.SoLuong;
                                    _context.Update(vxtlDiemTiem);

                                }


                            }
                            _context.ChiTietPhieuXuats.RemoveRange(detaillist);
                            lo.DaXoa = true;
                            _reposity.Update(lo);
                            _reposity.Save();
                            transaction.Commit();
                            return Ok();
                        }
                        else
                        {
                            transaction.Rollback();

                            return NotFound($"Không tìm thấy lô với id {id}");
                        }

                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    _logger.LogError(ex, ex.ToString());
                }



            }
            return BadRequest("Có lỗi xảy ra!");
        }
    }
}
