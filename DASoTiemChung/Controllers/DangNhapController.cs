using DASoTiemChung.Dtos.DangNhap;
using DASoTiemChung.Models;
using DASoTiemChung.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DASoTiemChung.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ILogger<DangNhapController> _logger;
        private readonly SoTiemChungContext _context;
        private readonly IGenericRepository<NhanVien> _reposity;

        public DangNhapController(ILogger<DangNhapController> logger, SoTiemChungContext context, IGenericRepository<NhanVien> reposity)
        {
            _logger = logger;
            _context = context;
            _reposity = reposity;
        }
        public const string RouteIndex = "LoginHome";
        [HttpGet("[controller]/", Name = RouteIndex)]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public const string LoginExcute = "LoginExcute";
        [HttpPost("[controller]/Login", Name = LoginExcute)]
        public async Task<IActionResult> Login(LoginDto input)
        {

            
            if (string.IsNullOrWhiteSpace(input.TenTaiKhoan) || string.IsNullOrWhiteSpace(input.MatKhau))
            {
                TempData["Message"] = "Tên tài khoản và mật khẩu không được bỏ trống!";
                return View("Index");
            }
            NhanVien nhanVien = _context.NhanViens.Include(x=>x.MaQuyenNavigation).FirstOrDefault(x => x.TenTaiKhoan.Trim().Equals(input.TenTaiKhoan) && x.MatKhau.Equals(input.MatKhau));
            if (nhanVien == null)
            {
                TempData["Message"] = "Tên tài khoản hoặc mật khẩu không chính xác!";

                return View("Index");
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, nhanVien.TenTaiKhoan),
                    new Claim(ClaimTypes.NameIdentifier, nhanVien.MaNhanVien.ToString()),
                     new Claim(ClaimTypes.Role, nhanVien.MaQuyenNavigation.TenQuyen.Replace(System.Environment.NewLine, string.Empty))
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Login");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect("/");
            
        }

        public const string LogoutExcute = "LogoutExcute";
        [HttpGet("[controller]/Logout", Name = LogoutExcute)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("AccessDenied")]
        public  IActionResult AccessDenied()
        {
            
            return View();
        }
    }
}
