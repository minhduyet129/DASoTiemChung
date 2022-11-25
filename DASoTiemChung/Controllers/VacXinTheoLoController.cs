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
    public class VacXinTheoLoController : Controller
    {
        private readonly ILogger<VacXinTheoLoController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<VacXinTheoLo> _reposity;

        public VacXinTheoLoController(ILogger<VacXinTheoLoController> logger, SoTiemChungContext context, IGenericRepository<VacXinTheoLo> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "VacXinTheoLoHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "VacXinTheoLoGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchVacXinTheoLoDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<VacXinTheoLo>> GetPagingLos(SearchVacXinTheoLoDto input)
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
            var query = _context.VacXinTheoLos.Include(x => x.MaKhoNavigation).Include(x => x.MaLoNavigation).Include(x => x.MaVacXinNavigation).Include(x => x.MaNhaSanXuatNavigation).AsQueryable();
            try
            {
                if (!string.IsNullOrEmpty(input.TenVacXinTheoLo))
                {
                    query = query.Where(x => x.TenVacXinTheoLo.Contains(input.TenVacXinTheoLo));
                }
                if (!string.IsNullOrEmpty(input.TenVacXin))
                {
                    query = query.Where(x => x.MaVacXinNavigation.TenVacXin.Contains(input.TenVacXin));
                }
                if (!string.IsNullOrEmpty(input.XuatXu))
                {
                    query = query.Where(x => x.XuatXu.Contains(input.XuatXu));
                }
                if (!string.IsNullOrEmpty(input.TenKho))
                {
                    query = query.Where(x => x.MaKhoNavigation.TenKho.Contains(input.TenKho));
                }
                if (!string.IsNullOrEmpty(input.TenNhaSanXuat))
                {
                    query = query.Where(x => x.MaNhaSanXuatNavigation.TenNhaSanXuat.Contains(input.TenNhaSanXuat));
                }
                if (!string.IsNullOrEmpty(input.TenLo))
                {
                    query = query.Where(x => x.MaLoNavigation.TenLo.Contains(input.TenLo));
                }
                if (input.NgaySanXuat.HasValue)
                {
                    query = query.Where(x => x.NgaySanXuat==input.NgaySanXuat.Value);
                }
                if (input.NgayHetHan.HasValue)
                {
                    query = query.Where(x => x.NgayHetHan == input.NgayHetHan.Value);
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<VacXinTheoLo> result = new PagedResultDto<VacXinTheoLo>(0, input.SkipCount, take, new List<VacXinTheoLo>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenVacXinTheoLo).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }
        public  const string RouteDataJson = "VacXinTheoLoGetDataJson";
        [HttpGet("[controller]/DataJson", Name = RouteDataJson)]
        public async Task<IActionResult> DataJsonAsync(SearchVacXinTheoLoDto input)
        {

            try
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

                var query = _context.VacXinTheoLos.AsQueryable();
                if(!string.IsNullOrEmpty(input.TenVacXinTheoLo))
                {
                    query = query.Where(x => x.TenVacXinTheoLo.Contains(input.TenVacXinTheoLo));
                }
                PagedResultDto<VacXinTheoLo> result = new PagedResultDto<VacXinTheoLo>(0, input.SkipCount, take, new List<VacXinTheoLo>());
                if (string.IsNullOrEmpty(input.TenVacXinTheoLo))
                {
                    query = query.OrderBy(x => x.TenVacXinTheoLo).Skip(skipRecord).Take(take);
                }


                query = query.OrderBy(x => x.TenVacXinTheoLo);

                result.Items = query.ToList();

                bool checkNull = (result != null);

                if (checkNull)
                {
                    result.SkipCount = input.SkipCount;
                    result.MaxResultCount = take;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            return Ok("Có lỗi !");
        }


        public const string RouteForm = "VacXinTheoLoGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            VacXinTheoLo result = new VacXinTheoLo();

            ViewBag.Los = _context.Los.OrderBy(x=>x.TenLo).ToList();
            ViewBag.Khos = _context.Khos.OrderBy(x=>x.TenKho).ToList();
            ViewBag.NhaSanXuats = _context.NhaSanXuats.OrderBy(x=>x.TenNhaSanXuat).ToList();
            ViewBag.VacXins = _context.VacXins.OrderBy(x=>x.TenVacXin).ToList();

            if (id == 0)
            {
                result.NgaySanXuat = DateTime.Now;
                result.NgayHetHan = DateTime.Now;
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

        public const string RouteCreate = "VacXinTheoLoPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(VacXinTheoLo dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenVacXinTheoLo == dto.TenVacXinTheoLo);
                if (find != null)
                {
                    return BadRequest("Tên đã tồn tại!");
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

        public const string RouteUpdate = "VacXinTheoLoPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, VacXinTheoLo dto)
        {

            if (id != dto.MaVacXinTheoLo)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenVacXinTheoLo == dto.TenVacXinTheoLo  && x.MaVacXinTheoLo != dto.MaVacXinTheoLo);
                if (find != null)
                {
                    return BadRequest("Tên đã tồn tại!");
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

        public const string RouteDelete = "VacXinTheoLoDelete";
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
