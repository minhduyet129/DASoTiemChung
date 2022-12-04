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
    [Authorize(Roles =Quyens.ThuKhoVaQuanLy)]
    public class KhoController : Controller
    {
        private readonly ILogger<KhoController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<Kho> _reposity;

        public KhoController(ILogger<KhoController> logger, SoTiemChungContext context, IGenericRepository<Kho> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "KhoHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public const string RouteDataGrid = "KhoGetDataGrid";
        [HttpGet("[controller]/DataGrid", Name = RouteDataGrid)]
        public async Task<IActionResult> DataGridAsync(SearchKhoDto input)
        {
            return PartialView("_DataGrid", await GetPagingLos(input)); 
        }

        private async Task<PagedResultDto<KhoOutputDto>> GetPagingLos(SearchKhoDto input)
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
            var query = from khos in _context.Khos
                        join xaphuongs in _context.XaPhuongs on khos.MaXaPhuong equals xaphuongs.MaXaPhuong into kxp

                        from khoxa in kxp.DefaultIfEmpty()

                        join quanhuyen in _context.QuanHuyens on khoxa.MaQuanHuyen equals quanhuyen.MaQuanHuyen into kxq

                        from khoxaquan in kxq.DefaultIfEmpty()

                        join tinh in _context.TinhThanhPhos on khoxaquan.MaTinhThanhPho equals tinh.MaTinhThanhPho into kxqt

                        from khoxaquantinh in kxqt.DefaultIfEmpty()
                        where !khos.DaXoa && !khos.Kieu

                        select new KhoOutputDto()
                        {
                            MaKho = khos.MaKho,
                            TenKho = khos.TenKho,
                            SoNha = khos.SoNha,
                            MaXaPhuong = khos.MaXaPhuong,
                            MaQuanHuyen = khos.MaQuanHuyen,
                            MaTinhThanhPho = khos.MaTinhThanhPho,
                            XaPhuongNavigation = khoxa,
                            QuanHuyenNavigation = khoxaquan,
                            TinhThanhPhoNavigation = khoxaquantinh
                        };
            try
            {
                if (!string.IsNullOrEmpty(input.TenKho))
                {
                    query = query.Where(x => x.TenKho.Contains(input.TenKho));
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
            PagedResultDto<KhoOutputDto> result = new PagedResultDto<KhoOutputDto>(0, input.SkipCount, take, new List<KhoOutputDto>());
            result.TotalCount = query.Count();
            query = query.OrderBy(x => x.TenKho).Skip(skipRecord).Take(take);



            result.Items = query.ToList();

            bool checkNull = (result != null);

            if (checkNull)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = take;
            }

            return result;
        }


        public const string RouteForm = "KhoGetForm";
        [HttpGet("[controller]/{id}", Name = RouteForm)]
        public async Task<IActionResult> Form(int id)
        {
            Kho result = new Kho();

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

        public const string RouteCreate = "KhoPostCreate";
        [HttpPost("[controller]/", Name = RouteCreate)]
        public async Task<IActionResult> Create(Kho dto)
        {

            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenKho == dto.TenKho && !x.DaXoa &&!x.Kieu );
                if (find != null)
                {
                    return BadRequest("Tên kho đã tồn tại!");
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

        public const string RouteUpdate = "KhoPutUpdate";
        [HttpPut("[controller]/{id}", Name = RouteUpdate)]
        public async Task<IActionResult> Update(int id, Kho dto)
        {

            if (id != dto.MaKho)
            {
                return BadRequest("Lỗi request!");
            }
            try
            {
                var find = _reposity.GetAll().FirstOrDefault(x => x.TenKho == dto.TenKho  && x.MaKho != dto.MaKho && !x.DaXoa && !x.Kieu);
                if (find != null)
                {
                    return BadRequest("Tên kho đã tồn tại!");
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

        public const string RouteDelete = "KhoDelete";
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
                        return NotFound($"Không tìm thấy kho với id {id}");
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
