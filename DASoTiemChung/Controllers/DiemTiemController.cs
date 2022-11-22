using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DASoTiemChung.Dtos.DiemTiem;
using DASoTiemChung.Filter;

namespace DASoTiemChung.Controllers
{
    public class DiemTiemController : Controller
    {
        private readonly ILogger<DiemTiemController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<DiemTiem> _reposity;

        public DiemTiemController(ILogger<DiemTiemController> logger, SoTiemChungContext context, IGenericRepository<DiemTiem> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "DiemTiemHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "DiemTiemGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchDiemTiemDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<DiemTiemOutputDto>> GetPagingLos(SearchDiemTiemDto input)
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
            var query = from diemtiems in _context.DiemTiems
                        join xaphuongs in _context.XaPhuongs on diemtiems.MaXaPhuong equals xaphuongs.MaXaPhuong into kxp

                        from diemtiemxa in kxp.DefaultIfEmpty()

                        join quanhuyen in _context.QuanHuyens on diemtiemxa.MaQuanHuyen equals quanhuyen.MaQuanHuyen into kxq

                        from diemtiemxaquan in kxq.DefaultIfEmpty()

                        join tinh in _context.TinhThanhPhos on diemtiemxaquan.MaTinhThanhPho equals tinh.MaTinhThanhPho into kxqt

                        from diemtiemxaquantinh in kxqt.DefaultIfEmpty()
                        select new DiemTiemOutputDto()
                        {
                            MaDiemTiem = diemtiems.MaDiemTiem,
                            TenDiemTiem = diemtiems.TenDiemTiem,
                            SoNha = diemtiems.SoNha,
                            MaXaPhuong = diemtiems.MaXaPhuong,
                            MaQuanHuyen = diemtiems.MaQuanHuyen,
                            MaTinhThanhPho = diemtiems.MaTinhThanhPho,
                            XaPhuongNavigation = diemtiemxa,
                            QuanHuyenNavigation = diemtiemxaquan,
                            TinhThanhPhoNavigation = diemtiemxaquantinh,
                            NguoiDungDau = diemtiems.NguoiDungDau,
                            NguoiTiem=diemtiems.NguoiTiem

                        };
            try
            {
                if (!string.IsNullOrEmpty(input.TenDiemTiem))
                {
                    query = query.Where(x => x.TenDiemTiem.Contains(input.TenDiemTiem));
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
            PagedResultDto<DiemTiemOutputDto> result = new PagedResultDto<DiemTiemOutputDto>(0, input.SkipCount, take, new List<DiemTiemOutputDto>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenDiemTiem).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "DiemTiemGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            DiemTiem result = new DiemTiem();

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

        public const string RouteCreate = "DiemTiemPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(DiemTiem dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenDiemTiem == dto.TenDiemTiem);
                if (find != null)
                {
                    return BadRequest("Tên điểm tiêm đã tồn tại!");
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

        public const string RouteUpdate = "DiemTiemPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, DiemTiem dto)
        {

            if (id != dto.MaDiemTiem)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenDiemTiem == dto.TenDiemTiem && x.MaDiemTiem != dto.MaDiemTiem);
                if (find != null)
                {
                    return BadRequest("Tên điểm tiêm đã tồn tại!");
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

        public const string RouteDelete = "DiemTiemDelete";
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
                        return NotFound($"Không tìm thấy điểm tiêm với id {id}");
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
