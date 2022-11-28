
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
    public class NhaSanXuatController : Controller
    {
        private readonly ILogger<NhaSanXuatController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<NhaSanXuat> _reposity;

        public NhaSanXuatController(ILogger<NhaSanXuatController> logger, SoTiemChungContext context, IGenericRepository<NhaSanXuat> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "NhaSanXuatHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "NhaSanXuatGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchNhaSanXuatDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<NhaSanXuat>> GetPagingLos(SearchNhaSanXuatDto input)
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
                if (!string.IsNullOrEmpty(input.TenNhaSanXuat))
                {
                    query = query.Where(x => x.TenNhaSanXuat.Contains(input.TenNhaSanXuat));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<NhaSanXuat> result = new PagedResultDto<NhaSanXuat>(0, input.SkipCount, take, new List<NhaSanXuat>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenNhaSanXuat).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "NhaSanXuatGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            NhaSanXuat result = new NhaSanXuat();



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

        public const string RouteCreate = "NhaSanXuatPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(NhaSanXuat dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenNhaSanXuat == dto.TenNhaSanXuat && x.SoDienThoai == dto.SoDienThoai && x.Email == dto.Email &&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên, số điện thoại hoặc email đã tồn tại!");
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

        public const string RouteUpdate = "NhaSanXuatPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, NhaSanXuat dto)
        {

            if (id != dto.MaNhaSanXuat)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => (x.TenNhaSanXuat == dto.TenNhaSanXuat || x.SoDienThoai == dto.SoDienThoai || x.Email == dto.Email) && x.MaNhaSanXuat != dto.MaNhaSanXuat&&!x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên, địa chỉ, số điện thoại hoặc email đã tồn tại!");
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

        public const string RouteDelete = "NhaSanXuatDelete";
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
                        return NotFound($"Không tìm thấy nhà sản xuất với id {id}");
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
