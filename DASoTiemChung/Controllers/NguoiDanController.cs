using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    [Authorize(Roles =Quyens.NhanVienVaQuanLy)]
    public class NguoiDanController : Controller
    {
        private readonly ILogger<NguoiDanController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<NguoiDan> _reposity;

        public NguoiDanController(ILogger<NguoiDanController> logger, SoTiemChungContext context, IGenericRepository<NguoiDan> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "NguoiDanHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "NguoiDanGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchNguoiDanDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<NguoiDanOutputDto>> GetPagingLos(SearchNguoiDanDto input)
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
            var query = from nguoidans in _context.NguoiDans
                        join xaphuongs in _context.XaPhuongs on nguoidans.MaXaPhuong equals xaphuongs.MaXaPhuong into kxp

                        from nguoidanxa in kxp.DefaultIfEmpty()

                        join quanhuyen in _context.QuanHuyens on nguoidanxa.MaQuanHuyen equals quanhuyen.MaQuanHuyen into kxq

                        from nguoidanxaquan in kxq.DefaultIfEmpty()

                        join tinh in _context.TinhThanhPhos on nguoidanxaquan.MaTinhThanhPho equals tinh.MaTinhThanhPho into kxqt

                        from nguoidanxaquantinh in kxqt.DefaultIfEmpty()
                        where !nguoidans.DaXoa
                        select new NguoiDanOutputDto()
                        {
                            MaNguoiDan = nguoidans.MaNguoiDan,
                            HoTen = nguoidans.HoTen,
                            SoNha = nguoidans.SoNha,
                            SoTheBaoHiemYte=nguoidans.SoTheBaoHiemYte,
                            SoCccdhc=nguoidans.SoCccdhc,
                            SoDienThoai=nguoidans.SoDienThoai,
                            NgheNghiep=nguoidans.NgheNghiep,
                            DonViCongTac=nguoidans.DonViCongTac,
                            Email=nguoidans.Email,
                            DanTocQuocTich=nguoidans.DanTocQuocTich,
                            NguoiDamHo=nguoidans.NguoiDamHo,
                            QuanHeNguoiDamHo=nguoidans.QuanHeNguoiDamHo,
                            SoDienThoaiNguoiDamHo=nguoidans.SoDienThoaiNguoiDamHo,
                            MaXaPhuong = nguoidans.MaXaPhuong,
                            MaQuanHuyen = nguoidans.MaQuanHuyen,
                            MaTinhThanhPho = nguoidans.MaTinhThanhPho,
                            XaPhuongNavigation = nguoidanxa,
                            QuanHuyenNavigation = nguoidanxaquan,
                            TinhThanhPhoNavigation = nguoidanxaquantinh
                        };
            try
            {
                if (!string.IsNullOrEmpty(input.HoTen))
                {
                    query = query.Where(x => x.HoTen.Contains(input.HoTen));
                }
                if (!string.IsNullOrEmpty(input.SoDienThoai))
                {
                    query = query.Where(x => x.SoDienThoai.Contains(input.SoDienThoai));
                }
                if (!string.IsNullOrEmpty(input.Email))
                {
                    query = query.Where(x => x.Email.Contains(input.Email));
                }
                if (!string.IsNullOrEmpty(input.SoCccdhc))
                {
                    query = query.Where(x => x.SoCccdhc.Contains(input.SoCccdhc));
                }
                if (!string.IsNullOrEmpty(input.SoNha))
                {
                    query = query.Where(x => x.SoNha.Contains(input.SoNha));
                }
                if (!string.IsNullOrEmpty(input.TenXaPhuong))
                {
                    query = query.Where(x => x.XaPhuongNavigation.TenXaPhuong.Contains(input.TenXaPhuong));
                }
                if (!string.IsNullOrEmpty(input.TenQuanHuyen))
                {
                    query = query.Where(x => x.QuanHuyenNavigation.TenQuanHuyen.Contains(input.TenQuanHuyen));
                }
                if (!string.IsNullOrEmpty(input.TenTinhThanh))
                {
                    query = query.Where(x => x.TinhThanhPhoNavigation.TenTinhThanhPho.Contains(input.TenTinhThanh));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<NguoiDanOutputDto> result = new PagedResultDto<NguoiDanOutputDto>(0, input.SkipCount, take, new List<NguoiDanOutputDto>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.HoTen).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "NguoiDanGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            NguoiDan result = new NguoiDan();

            ViewBag.TinhThanhs = _context.TinhThanhPhos.ToList();

            if (id == 0)
            {
                return PartialView("_Form", result);
            }


            try
            {
                result = _reposity.GetById(id);
                ViewBag.QuanHuyens = _context.QuanHuyens.Where(x => x.MaTinhThanhPho == result.MaTinhThanhPho).ToList();
                ViewBag.XaPhuongs = _context.XaPhuongs.Where(x => x.MaQuanHuyen == result.MaQuanHuyen).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }



            return PartialView("_Form", result);
        }

        public const string RouteCreate = "NguoiDanPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(NguoiDan dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.SoCccdhc.Trim() == dto.SoCccdhc.Trim() && x.SoTheBaoHiemYte.Trim() == dto.SoTheBaoHiemYte.Trim() && !x.DaXoa);
                if (find != null)
                {
                    return BadRequest(" số điện thoại hoặc số thẻ bảo hiểm y tế đã tồn tại!");
                }
                _reposity.Insert(dto);
                _reposity.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }


            return BadRequest("Có lỗi khi xử lý!");

        }

        public const string RouteUpdate = "NguoiDanPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, NguoiDan dto)
        {

            if (id != dto.MaNguoiDan)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.SoCccdhc.Trim() == dto.SoCccdhc.Trim() && x.MaNguoiDan != dto.MaNguoiDan&& !x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Người dân đã tồn tại!");
                }
                var lo = _reposity.GetById(id);
                if (lo != null)
                {
                    
                    _reposity.Update(dto);
                    _reposity.Save();
                    return Ok();
                }
                return NotFound("Không tìm thấy!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            return BadRequest("Có lỗi khi xử lý!");
        }

        public const string RouteDelete = "NguoiDanDelete";
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
                        _reposity.Delete(id);
                        _reposity.Save();
                        return Ok();
                    }
                    else
                    {
                        return NotFound($"Không tìm thấy người dân với id {id}");
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
