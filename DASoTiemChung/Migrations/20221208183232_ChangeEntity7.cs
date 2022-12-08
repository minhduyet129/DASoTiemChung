using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntity7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaKho",
                table: "PhieuNhap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaKho",
                table: "PhieuNhap",
                column: "MaKho");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_Kho_MaKho",
                table: "PhieuNhap",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_Kho_MaKho",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaKho",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "PhieuNhap");
        }
    }
}
