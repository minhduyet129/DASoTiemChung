namespace DASoTiemChung
{
    public static class Quyens
    {

        public const string QuanLy = "QuanLy";
        //Quản lý thủ tục tiêm
        public const string NhanVienCapCao = "NhanVienCapCao";
        //--Thêm
        public const string NhanVien = "NhanVien";
        public const string ThemThuTucTiem = "NhanVien,NhanVienCapCao,QuanLy";
        //--Sửa và xoá
        public const string ChinhSuaThuTucTiem = "NhanVienCapCao,QuanLy";

        //Quản lý liên quan đến kho
        public const string TruongKho = "TruongKho";
        //--Thêm
        public const string ThuKho = "ThuKho";
        public const string ThemKho = "ThuKho,TruongKho,QuanLy";
        //--Sửa và xoá
        public const string ChinhSuaKho = "TruongKho,QuanLy";




        public const string BaoHong = "NhanVienCapCao,TruongKho,QuanLy";



    }
}
