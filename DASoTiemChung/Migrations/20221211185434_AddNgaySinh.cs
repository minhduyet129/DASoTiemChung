using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class AddNgaySinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "NguoiDan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "NguoiDan");
        }
    }
}
