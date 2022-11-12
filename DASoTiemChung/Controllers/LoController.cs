using DASoTiemChung.Dtos;
using DASoTiemChung.Dtos.Lo;
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
    public class LoController : Controller
    {
        private readonly ILogger<LoController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<Lo> _reposity;

        public LoController(ILogger<LoController> logger, SoTiemChungContext context, IGenericRepository<Lo> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public  const string RouteIndex = "LoHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public  const string RouteDataGrid = "LoGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchLoDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<Lo>> GetPagingLos(SearchLoDto input)
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
            var query = _reposity.GetAll();
            try
            {
                if (!string.IsNullOrEmpty(input.TenLo))
                {
                    query = query.Where(x => x.TenLo.Contains(input.TenLo));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<Lo> result = new PagedResultDto<Lo>(0, input.SkipCount, take, new List<Lo>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenLo).Skip(skipRecord).Take(take);

            
            
            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "LoGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            Lo result = new Lo();



            if (id==0)
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

        public const string RouteCreate = "LoPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(Lo dto)
        {
            
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenLo == dto.TenLo || x.Code == dto.Code);
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

        public const string RouteUpdate = "CategoryPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, Lo dto)
        {

            if (id != dto.MaLo)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenLo == dto.TenLo || x.Code == dto.Code);
                if (find != null)
                {
                    return BadRequest("Tên hoặc mã code đã tồn tại!");
                }
                var lo=_reposity.GetById(id);
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

        public const string RouteDelete = "LoDeleteDelete";
        [HttpDelete("[controller]/{id}", Name = RouteDelete)]
        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id.HasValue)
                {
                    var lo =_reposity.GetById(id.Value);
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
