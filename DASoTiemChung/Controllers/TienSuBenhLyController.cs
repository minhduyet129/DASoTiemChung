
using DASoTiemChung.Dtos;
using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class TienSuBenhLyController : Controller
    {
        private readonly ILogger<TienSuBenhLyController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<TienSuBenhLy> _reposity;

        public TienSuBenhLyController(ILogger<TienSuBenhLyController> logger, SoTiemChungContext context, IGenericRepository<TienSuBenhLy> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "TienSuBenhLyHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "TienSuBenhLyGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchTienSuBenhLyDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<TienSuBenhLy>> GetPagingLos(SearchTienSuBenhLyDto input)
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
            var query = _reposity.GetAll().Where(x=>!x.DaXoa);
            try
            {
                if (!string.IsNullOrEmpty(input.TenBenhLy))
                {
                    query = query.Where(x => x.TenBenhLy.Contains(input.TenBenhLy));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<TienSuBenhLy> result = new PagedResultDto<TienSuBenhLy>(0, input.SkipCount, take, new List<TienSuBenhLy>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenBenhLy).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "TienSuBenhLyGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            TienSuBenhLy result = new TienSuBenhLy();



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

        public const string RouteCreate = "TienSuBenhLyPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(TienSuBenhLy dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenBenhLy == dto.TenBenhLy&&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên hoặc mã code đã tồn tại!");
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

        public const string RouteUpdate = "TienSuBenhLyPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, TienSuBenhLy dto)
        {

            if (id != dto.MaBenhLy)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => (x.TenBenhLy == dto.TenBenhLy) && x.MaBenhLy != dto.MaBenhLy&&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên bệnh lý đã tồn tại");
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

        public const string RouteDelete = "TienSuBenhLyDelete";
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
                        _reposity.Update(lo);
                        _reposity.Save();
                        return Ok();
                    }
                    else
                    {
                        return NotFound($"Không tìm thấy bệnh lý với id {id}");
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
