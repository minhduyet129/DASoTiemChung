using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntityRemoveMaBenhLy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhieuTiem_MaBenhLy",
                table: "PhieuTiem");

            migrationBuilder.DropColumn(
                name: "MaBenhLy",
                table: "PhieuTiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaBenhLy",
                table: "PhieuTiem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaBenhLy",
                table: "PhieuTiem",
                column: "MaBenhLy");
        }
    }
}
