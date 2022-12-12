using System.ComponentModel.DataAnnotations;

namespace DASoTiemChung.Dtos
{
    public class TraCuuInputDto
    {
        [Required(ErrorMessage ="Vui lòng nhập tên người dân")]
        public string TenNguoiDan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số căn cước công dân")]
        public string SoCCCDHC { get; set; }
    }
}
