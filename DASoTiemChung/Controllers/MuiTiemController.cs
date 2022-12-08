
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
    [Authorize(Roles =Quyens.ThemThuTucTiem)]
    public class MuiTiemController : Controller
    {
        private readonly ILogger<MuiTiemController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<MuiTiem> _reposity;

        public MuiTiemController(ILogger<MuiTiemController> logger, SoTiemChungContext context, IGenericRepository<MuiTiem> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "MuiTiemHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string RouteDataGrid = "MuiTiemGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchMuiTiemDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input));
        }

        private async Task<PagedResultDto<MuiTiem>> GetPagingLos(SearchMuiTiemDto input)
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
                if (!string.IsNullOrEmpty(input.TenMuiTiem))
                {
                    query = query.Where(x => x.TenMuiTiem.Contains(input.TenMuiTiem));
                }


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
            PagedResultDto<MuiTiem> result = new PagedResultDto<MuiTiem>(0, input.SkipCount, take, new List<MuiTiem>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenMuiTiem).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "MuiTiemGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            MuiTiem result = new MuiTiem();



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

        public const string RouteCreate = "MuiTiemPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(MuiTiem dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenMuiTiem == dto.TenMuiTiem &&!x.DaXoa);
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

        public const string RouteUpdate = "MuiTiemPutUpdate";
        [Authorize(Roles = Quyens.ChinhSuaThuTucTiem)]

        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, MuiTiem dto)
        {

            if (id != dto.MaMuiTiem)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => (x.TenMuiTiem == dto.TenMuiTiem) && x.MaMuiTiem != dto.MaMuiTiem && !x.DaXoa);
                if (find != null)
                {
                    return BadRequest("Tên hoặc đã tồn tại!");
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

        public const string RouteDelete = "MuiTiemDelete";
        [Authorize(Roles = Quyens.ChinhSuaThuTucTiem)]
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
                        return NotFound($"Không tìm thấy mũi tiêm với id {id}");
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

