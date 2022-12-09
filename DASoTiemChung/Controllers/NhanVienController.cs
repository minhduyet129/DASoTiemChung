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
    [Authorize(Roles = Quyens.QuanLy)]
    public class NhanVienController : Controller
    {
        private readonly ILogger<NhanVienController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<NhanVien> _reposity;

        public NhanVienController(ILogger<NhanVienController> logger, SoTiemChungContext context, IGenericRepository<NhanVien> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "NhanVienHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {
            ViewBag.Roles = _context.Quyens.ToList().Where(x => !x.DaXoa);

            return View();
        }

        public const string RouteDataGrid = "NhanVienGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchNhanVienDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<NhanVien>> GetPagingLos(SearchNhanVienDto input)
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
            var query = _context.NhanViens.Include(y=>y.MaQuyenNavigation).Where(x=>!x.DaXoa).AsQueryable();
            query = from nhanviens in query
                    join khos in _context.Khos on nhanviens.MaKho equals khos.MaKho into tonghop
                    from nhanvienKho in tonghop.DefaultIfEmpty()
                    select new NhanVien()
                    {
                        MaNhanVien = nhanviens.MaNhanVien,
                        MaKho = nhanviens.MaKho,
                        DaXoa = nhanviens.DaXoa,
                        MaQuyen = nhanviens.MaQuyen,
                        MaKhoNavigation = nhanvienKho,
                        MaQuyenNavigation = nhanviens.MaQuyenNavigation,
                        MatKhau = nhanviens.MatKhau,
                        SoDienThoai = nhanviens.SoDienThoai,
                        TenNhanVien = nhanviens.TenNhanVien,
                        TenTaiKhoan = nhanviens.TenTaiKhoan
                    };
            try
            {
                if (!string.IsNullOrEmpty(input.TenNhanVien))
                {
                    query = query.Where(x => x.TenNhanVien.Contains(input.TenNhanVien));
                }
                if (!string.IsNullOrEmpty(input.TenTaiKhoan))
                {
                    query = query.Where(x => x.TenTaiKhoan.Contains(input.TenTaiKhoan));
                }
                if (!string.IsNullOrEmpty(input.SoDienThoai))
                {
                    query = query.Where(x => x.SoDienThoai.Contains(input.SoDienThoai));
                }
                if (input.MaQuyen.HasValue)
                {
                    query = query.Where(x => x.MaQuyen==input.MaQuyen.Value);
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<NhanVien> result = new PagedResultDto<NhanVien>(0, input.SkipCount, take, new List<NhanVien>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenTaiKhoan).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "NhanVienGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            NhanVien result = new NhanVien();

            ViewBag.Roles = _context.Quyens.Where(x => !x.DaXoa).ToList();
            ViewBag.Khos= _context.Khos.Where(x=>!x.DaXoa).ToList();

            if (id == 0)
            {

                return PartialView("_Form", result);
            }


            try
            {
                result = _reposity.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }



            return PartialView("_Form", result);
        }

        public const string RouteCreate = "NhanVienPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(NhanVien dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenTaiKhoan == dto.TenTaiKhoan&&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên tài khoản đã tồn tại!");
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

        public const string RouteUpdate = "NhanVienPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, NhanVien dto)
        {

            if (id != dto.MaNhanVien)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenTaiKhoan == dto.TenTaiKhoan&& x.MaNhanVien != dto.MaNhanVien&&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên tài khoản đã tồn tại!");
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

        public const string RouteDelete = "NhanVienDelete";
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
                        lo.DaXoa = true;
                        lo.TenNhanVien += " (Đã xóa)";
                        _reposity.Update(lo);
                        _reposity.Save();
                        return Ok();
                    }
                    else
                    {
                        return NotFound($"Không tìm thấy nhân viên với id {id}");
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
