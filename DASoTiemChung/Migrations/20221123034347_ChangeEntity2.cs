using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianXuat",
                table: "ChiTietPhieuXuat");

            migrationBuilder.DropColumn(
                name: "ThoiGianNhap",
                table: "ChiTietPhieuNhap");

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuat",
                table: "PhieuXuat",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianNhap",
                table: "PhieuNhap",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianXuat",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "ThoiGianNhap",
                table: "PhieuNhap");

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuat",
                table: "ChiTietPhieuXuat",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianNhap",
                table: "ChiTietPhieuNhap",
                type: "datetime",
                nullable: true);
        }
    }
}
