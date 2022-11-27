//using DASoTiemChung.Dtos;
//using DASoTiemChung.Filter;
//using DASoTiemChung.Models;
//using DASoTiemChung.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DASoTiemChung.Controllers
//{
//    public class PhieuTiemController : Controller
//    {
//        private readonly ILogger<PhieuTiemController> _logger;
//        private readonly SoTiemChungContext _context;
//        private readonly IGenericRepository<PhieuTiem> _reposity;

//        public PhieuTiemController(ILogger<PhieuTiemController> logger, SoTiemChungContext context, IGenericRepository<PhieuTiem> reposity)
//        {
//            _logger = logger;
//            _context = context;
//            _reposity = reposity;
//        }
//        public const string RouteIndex = "PhieuTiemHome";
//        [HttpGet("[controller]/", Name = RouteIndex)]
//        public async Task<IActionResult> Index()
//        {

//            return View();
//        }

//        public const string RouteDataGrid = "PhieuTiemGetDataGrid";
//        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
//        public async Task<IActionResult> DataGridAsync(SearchPhieuTiemDto input)
//        {
//            return PartialView("_DataGrid", await GetPagingLos(input));
//        }

//        private async Task<PagedResultDto<PhieuTiem>> GetPagingLos(SearchPhieuTiemDto input)
//        {

//            if (input.SkipCount < 0)
//            {
//                input.SkipCount = 0;
//            }
//            if (input.MaxResultCount <= 0)
//            {
//                input.MaxResultCount = 10;
//            }
//            int skipRecord = (input.SkipCount - 1) * input.MaxResultCount;
//            var take = input.MaxResultCount;
//            var query = _context.PhieuTiems.Include(x => x.MaVacXinNavigation).Include(x => x.MaNguoiDanNavigation).Include(x => x.MaMuiTiemNavigation).Include(x => x.MaDiemTiemNavigation).AsQueryable();
//            try
//            {
//                if (!string.IsNullOrEmpty(input.TenNguoiDan))
//                {
//                    query = query.Where(x => x.MaNguoiDanNavigation.HoTen.Contains(input.TenNguoiDan));
//                }
//                if (!string.IsNullOrEmpty(input.TenDiemTiem))
//                {
//                    query = query.Where(x => x.MaDiemTiemNavigation.TenDiemTiem.Contains(input.TenDiemTiem));
//                }
//                if (!string.IsNullOrEmpty(input.SoDienThoai))
//                {
//                    query = query.Where(x => x.MaNguoiDanNavigation.SoDienThoai.Contains(input.SoDienThoai));
//                }
//                if (!string.IsNullOrEmpty(input.TenVacXin))
//                {
//                    query = query.Where(x => x.MaVacXinNavigation.TenVacXin.Contains(input.TenVacXin));
//                }


//            }

//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.ToString());
//            }
//            PagedResultDto<PhieuTiem> result = new PagedResultDto<PhieuTiem>(0, input.SkipCount, take, new List<PhieuTiem>());
//            result.TotalCount = query.Count();
//            query = query.OrderByDescending(x => x.MaPhieuTiem).Skip(skipRecord).Take(take);



//            result.Items = query.ToList();

//            bool checkNull = (result != null);

//            if (checkNull)
//            {
//                result.SkipCount = input.SkipCount;
//                result.MaxResultCount = take;
//            }

//            return result;
//        }


//        public const string RouteForm = "PhieuTiemGetForm";
//        [HttpGet("[controller]/{id}", Name = RouteForm)]
//        public async Task<IActionResult> Form(int id)
//        {
//            PhieuTiemInputDto result = new PhieuTiemInputDto();



//            if (id == 0)
//            {
//                return PartialView("_Form", result);
//            }


//            try
//            {
//                result = _context.PhieuTiems.Include(x => x.MaNguoiDanNavigation).Select(x => new PhieuTiemInputDto()
//                {
//                    MaPhieuTiem=x.MaPhieuTiem,
//                    TenNguoiDan=x.MaNguoiDanNavigation.HoTen,
//                    SoDienThoai=x.MaNguoiDanNavigation.SoDienThoai,
//                    ThoiGianTiem=x.ThoiGianTiem,
//                    MaMuiTiem = x.MaMuiTiem,
//                    MaDiemTiem=x.MaDiemTiem,
//                    MaVacXin=x.MaVacXin,
//                    PhanUngSauTiem=x.PhanUngSauTiem

//                }).FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.ToString());
//            }



//            return PartialView("_Form", result);
//        }

//        public const string RouteCreate = "LoPostCreate";
//        [HttpPost("[controller]/", Name = RouteCreate)]
//        public async Task<IActionResult> Create(Lo dto)
//        {

//            try
//            {
//                var find = _reposity.GetAll().FirstOrDefault(x => x.TenLo == dto.TenLo || x.Code == dto.Code);
//                if (find != null)
//                {
//                    return BadRequest("Tên hoặc mã code đã tồn tại!");
//                }
//                _reposity.Insert(dto);
//                _reposity.Save();
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.ToString());
//            }


//            return BadRequest("Có lỗi khi xử lý!");

//        }

//        public const string RouteUpdate = "LoPutUpdate";
//        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
//        public async Task<IActionResult> Update(int id, Lo dto)
//        {

//            if (id != dto.MaLo)
//            {
//                return BadRequest("Lỗi request!");
//            }
//            try
//            {
//                var find = _reposity.GetAll().FirstOrDefault(x => (x.TenLo == dto.TenLo || x.Code == dto.Code) && x.MaLo != dto.MaLo);
//                if (find != null)
//                {
//                    return BadRequest("Tên hoặc mã code đã tồn tại!");
//                }
//                var lo = _reposity.GetById(id);
//                if (lo != null)
//                {

//                    _reposity.Update(dto);
//                    _reposity.Save();
//                    return Ok();
//                }
//                return NotFound("Không tìm thấy!");

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.ToString());
//            }

//            return BadRequest("Có lỗi khi xử lý!");
//        }

//        public const string RouteDelete = "LoDelete";
//        [HttpDelete("[controller]/{id}", Name = RouteDelete)]
//        public async Task<IActionResult> Delete(int? id)
//        {

//            try
//            {
//                if (id.HasValue)
//                {
//                    var lo = _reposity.GetById(id.Value);
//                    if (lo != null)
//                    {
//                        _reposity.Delete(id);
//                        _reposity.Save();
//                        return Ok();
//                    }
//                    else
//                    {
//                        return NotFound($"Không tìm thấy lô với id {id}");
//                    }

//                }

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.ToString());
//            }


//            return BadRequest("Có lỗi xảy ra!");

//        }
//    }
//}
