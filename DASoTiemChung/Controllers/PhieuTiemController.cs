﻿using DASoTiemChung.Dtos;
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
    public class PhieuTiemController : Controller
    {
        private readonly ILogger<PhieuTiemController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<PhieuTiem> _reposity;

        public PhieuTiemController(ILogger<PhieuTiemController> logger, SoTiemChungContext context, IGenericRepository<PhieuTiem> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "PhieuTiemHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "PhieuTiemGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchPhieuTiemDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<PhieuTiem>> GetPagingLos(SearchPhieuTiemDto input)
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
            var query = _context.PhieuTiems.Include(x => x.MaVacXinNavigation).Include(x => x.MaNguoiDanNavigation).Include(x => x.MaMuiTiemNavigation).Include(x => x.MaDiemTiemNavigation).Where(x => !x.DaXoa).AsQueryable();
            try
            {
                if (!string.IsNullOrEmpty(input.TenNguoiDan))
                {
                    query = query.Where(x => x.MaNguoiDanNavigation.HoTen.Contains(input.TenNguoiDan));
                }
                if (!string.IsNullOrEmpty(input.TenDiemTiem))
                {
                    query = query.Where(x => x.MaDiemTiemNavigation.TenDiemTiem.Contains(input.TenDiemTiem));
                }
                if (!string.IsNullOrEmpty(input.SoCccdhc))
                {
                    query = query.Where(x => x.MaNguoiDanNavigation.SoDienThoai.Contains(input.SoCccdhc));
                }
                if (!string.IsNullOrEmpty(input.TenVacXin))
                {
                    query = query.Where(x => x.MaVacXinNavigation.TenVacXin.Contains(input.TenVacXin));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<PhieuTiem> result = new PagedResultDto<PhieuTiem>(0, input.SkipCount, take, new List<PhieuTiem>());
            result.TotalCount = query.Count();
            query = query.OrderByDescending(x => x.MaPhieuTiem).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "PhieuTiemGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            PhieuTiemInputDto result = new PhieuTiemInputDto();


            ViewBag.BenhLys = _context.TienSuBenhLies.Where(x => !x.DaXoa).OrderBy(x => x.MaBenhLy).ToList();
            ViewBag.MuiTiems = _context.MuiTiems.Where(x => !x.DaXoa).OrderBy(x => x.TenMuiTiem).ToList();
            ViewBag.DiemTiems = _context.DiemTiems.Where(x => !x.DaXoa).OrderBy(x => x.TenDiemTiem).ToList();
            ViewBag.VacXins = _context.VacXins.Where(x => !x.DaXoa).OrderBy(x => x.TenVacXin).ToList();



            if (id == 0)
            {
                result.ThoiGianTiem = DateTime.Now;
                return PartialView("_Form", result);
            }

            try
            {
                result = _context.PhieuTiems.Include(x => x.MaNguoiDanNavigation).Include(x => x.PhieuTiemBenhLys).ThenInclude(x => x.MaTienSuBenhLyNavigation).Select(x => new PhieuTiemInputDto()
                {
                    MaPhieuTiem = x.MaPhieuTiem,
                    TenNguoiDan = x.MaNguoiDanNavigation.HoTen,
                    SoCccdhc = x.MaNguoiDanNavigation.SoCccdhc,
                    ThoiGianTiem = x.ThoiGianTiem,
                    MaMuiTiem = x.MaMuiTiem,
                    MaDiemTiem = x.MaDiemTiem,
                    MaVacXin = x.MaVacXin,
                    PhanUngSauTiem = x.PhanUngSauTiem,
                    PhieuTiemBenhLys = x.PhieuTiemBenhLys

                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }



            return PartialView("_Form", result);
        }

        public const string RouteCreate = "PhieuTiemPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(PhieuTiemInputDto dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var nguoidan = _context.NguoiDans.FirstOrDefault(x => x.HoTen == dto.TenNguoiDan && x.SoCccdhc == dto.SoCccdhc && !x.DaXoa);
                    if (nguoidan == null)
                    {
                        return BadRequest("Người dân không tồn tại!Vui lòng kiểm tra lại hoặc thêm mới người dân");
                    }
                    PhieuTiem phieutiem = new PhieuTiem()
                    {
                        MaNguoiDan = nguoidan.MaNguoiDan,
                        MaDiemTiem = dto.MaDiemTiem,
                        MaMuiTiem = dto.MaMuiTiem,
                        ThoiGianTiem = dto.ThoiGianTiem,
                        MaVacXin = dto.MaVacXin,
                        PhieuTiemBenhLys = dto.PhieuTiemBenhLys,
                        PhanUngSauTiem = dto.PhanUngSauTiem,


                    };
                    _context.PhieuTiems.Add(phieutiem);
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

        public const string RouteUpdate = "PhieuTiemPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, PhieuTiemInputDto dto)
        {

            if (id != dto.MaPhieuTiem)
            {
                return BadRequest("Lỗi request!");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {

                    var nguoidan = _context.NguoiDans.FirstOrDefault(x => x.HoTen == dto.TenNguoiDan && x.SoCccdhc == dto.SoCccdhc && !x.DaXoa);
                    if (nguoidan == null)
                    {
                        return BadRequest("Người dân không tồn tại!Vui lòng kiểm tra lại hoặc thêm mới người dân");
                    }
                    var phieutiem = _context.PhieuTiems.Find(id);
                    if (phieutiem != null)
                    {
                        phieutiem.MaVacXin = dto.MaVacXin;
                        phieutiem.MaDiemTiem = dto.MaDiemTiem;
                        phieutiem.MaMuiTiem = dto.MaMuiTiem;
                        phieutiem.MaNguoiDan = nguoidan.MaNguoiDan;
                        phieutiem.PhanUngSauTiem = dto.PhanUngSauTiem;
                        phieutiem.ThoiGianTiem = dto.ThoiGianTiem;

                        _context.PhieuTiems.Update(phieutiem);
                        _context.SaveChanges();

                        var listPhieuTiemRemove = _context.PhieuTiemBenhLys.Where(x => x.MaPhieuTiem == phieutiem.MaPhieuTiem).ToList();
                        _context.PhieuTiemBenhLys.RemoveRange(listPhieuTiemRemove);
                        _context.SaveChanges();

                        foreach (var detail in dto.PhieuTiemBenhLys)
                        {
                            detail.MaPhieuTiem = phieutiem.MaPhieuTiem;
                            _context.PhieuTiemBenhLys.Add(detail);

                        }
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok();
                    }
                    else
                    {
                        return NotFound("Không tìm thấy phiếu tiêm cần sửa!");
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

        public const string RouteDelete = "PhieuTiemDelete";
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
                        var detaillist = _context.PhieuTiemBenhLys.Where(x => x.MaPhieuTiem == lo.MaPhieuTiem).ToList();
                        _context.PhieuTiemBenhLys.RemoveRange(detaillist);

                        _reposity.Delete(id);
                        _reposity.Save();
                        return Ok();
                    }
                    else
                    {
                        return NotFound($"Không tìm thấy phiếu tiêm với id {id}");
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
