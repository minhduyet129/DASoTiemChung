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
    public class PhieuNhapController : Controller
    {
        private readonly ILogger<PhieuNhapController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<PhieuNhap> _reposity;

        public PhieuNhapController(ILogger<PhieuNhapController> logger, SoTiemChungContext context, IGenericRepository<PhieuNhap> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "PhieuNhapHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "PhieuNhapGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchPhieuNhapDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<PhieuNhap>> GetPagingLos(SearchPhieuNhapDto input)
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
            var query = _context.PhieuNhaps.Include(x => x.MaNhanVienNavigation).AsQueryable().Where(x=>!x.DaXoa);
            try
            {
                if (!string.IsNullOrEmpty(input.MaPhieuNhap))
                {
                    query = query.Where(x => x.MaPhieuNhap.ToString().Contains(input.MaPhieuNhap.ToString()));
                }
                if (!string.IsNullOrEmpty(input.TenNhanVien))
                {
                    query = query.Where(x => x.MaNhanVienNavigation.TenTaiKhoan.Contains(input.TenNhanVien));
                }
                if (input.ThoiGianNhap.HasValue)
                {
                    query = query.Where(x => x.ThoiGianNhap.Equals(input.ThoiGianNhap));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<PhieuNhap> result = new PagedResultDto<PhieuNhap>(0, input.SkipCount, take, new List<PhieuNhap>());
            result.TotalCount = query.Count();
            query = query.OrderByDescending(x => x.MaPhieuNhap).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "PhieuNhapGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            PhieuNhap result = new PhieuNhap();
            
            ViewBag.NhanViens = _context.NhanViens.OrderBy(x => x.TenNhanVien).ToList();

            if (id == 0)
            {

                result.ThoiGianNhap = DateTime.Now;
                return PartialView("_Form", result);
            }


            try
            {
                result = _context.PhieuNhaps.Include(x => x.MaNhanVienNavigation).Include(x => x.ChiTietPhieuNhaps).ThenInclude(x=>x.MaVacXinTheoLoNavigation).FirstOrDefault(x=>x.MaPhieuNhap==id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }



            return PartialView("_Form", result);
        }

        public const string RouteCreate = "PhieuNhapPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(PhieuNhap dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    
                    decimal sum = 0;
                    foreach (var ctpn in dto.ChiTietPhieuNhaps)
                    {
                        ctpn.ThanhTien = ctpn.DonGia * ctpn.SoLuong;
                        sum += ctpn.ThanhTien.HasValue ? ctpn.ThanhTien.Value : 0;

                    }
                    dto.Tongtien = sum;

                    _reposity.Insert(dto);
                    _reposity.Save();
                    foreach (var ctpn in dto.ChiTietPhieuNhaps)
                    {
                        
                        ctpn.MaPhieuNhap = dto.MaPhieuNhap;
                        //await _context.ChiTietPhieuNhaps.AddAsync(ctpn);
                        var vacXinTheoLo = _context.VacXinTheoLos.Find(ctpn.MaVacXinTheoLo);
                        if (vacXinTheoLo != null)
                        {
                            vacXinTheoLo.SoLuong+=ctpn.SoLuong;
                            _context.Update(vacXinTheoLo);
                        }
                        else
                        {
                            transaction.Rollback();
                            return BadRequest("Không tìm thấy vắc xin theo lô cần nhập");
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

        public const string RouteUpdate = "PhieuNhapPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, PhieuNhap dto)
        {

            if (id != dto.MaPhieuNhap)
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
                        decimal sum = 0;
                        foreach (var ctpn in dto.ChiTietPhieuNhaps)
                        {
                            ctpn.ThanhTien = ctpn.DonGia * ctpn.SoLuong;
                            sum += ctpn.ThanhTien.HasValue ? ctpn.ThanhTien.Value : 0;

                        }
                        lo.Tongtien = sum;
                        lo.GhiChu = dto.GhiChu;
                        lo.MaNhanVien = dto.MaNhanVien;
                        lo.ThoiGianNhap = dto.ThoiGianNhap;
                      
                        var childrens = dto.ChiTietPhieuNhaps;
                        dto.ChiTietPhieuNhaps = null;
                        _reposity.Update(lo);
                        _reposity.Save();

                        var detaillist = _context.ChiTietPhieuNhaps.Where(x => x.MaPhieuNhap == dto.MaPhieuNhap).ToList();
                        foreach (var giam in detaillist)
                        {

                            
                            //await _context.ChiTietPhieuNhaps.AddAsync(ctpn);
                            var vacXinTheoLo = _context.VacXinTheoLos.Find(giam.MaVacXinTheoLo);
                            if (vacXinTheoLo != null)
                            {
                                vacXinTheoLo.SoLuong -= giam.SoLuong;
                                _context.Update(vacXinTheoLo);
                            }
                            

                        }
                        _context.ChiTietPhieuNhaps.RemoveRange(detaillist);

                        foreach (var ctpn in childrens)
                        {
                            ctpn.MaPhieuNhap = dto.MaPhieuNhap;
                            var vacXinTheoLo = _context.VacXinTheoLos.Find(ctpn.MaVacXinTheoLo);
                            if (vacXinTheoLo != null)
                            {
                                vacXinTheoLo.SoLuong += ctpn.SoLuong;
                                _context.Update(vacXinTheoLo);
                            }
                            else
                            {
                                transaction.Rollback();
                                return BadRequest($"Không tìm thấy vắc xin theo lô có mã {ctpn.MaVacXinTheoLo} cần nhập");
                            }
                            _context.ChiTietPhieuNhaps.Add(ctpn);

                        }
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok();
                    }
                    return NotFound("Không tìm thấy!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, ex.ToString());
                }
            }

         

            return BadRequest("Có lỗi khi xử lý!");
        }

        public const string RouteDelete = "PhieuNhapDelete";
        [HttpDelete("[controller]/{id}", Name = RouteDelete)]
        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id.HasValue)
                {
                    var lo = _reposity.GetById(id.Value);
                    if (lo != null)
                    {
                        var detaillist = _context.ChiTietPhieuNhaps.Where(x => x.MaPhieuNhap == lo.MaPhieuNhap).ToList();
                        _context.ChiTietPhieuNhaps.RemoveRange(detaillist);
                        lo.DaXoa = true;
                        _reposity.Update(lo);
                        _reposity.Save();
                        return Ok();
                    }
                    else
                    {
                        return NotFound($"Không tìm thấy lô với id {id}");
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }


            return BadRequest("Có lỗi xảy ra!");

        }
    }
}
