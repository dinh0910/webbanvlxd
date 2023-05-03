using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanvlxd.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietDatHang",
                columns: table => new
                {
                    ChiTietDatHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatHangID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDatHang", x => x.ChiTietDatHangID);
                    table.ForeignKey(
                        name: "FK_ChiTietDatHang_DatHang_DatHangID",
                        column: x => x.DatHangID,
                        principalTable: "DatHang",
                        principalColumn: "DatHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDatHang_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_LoaiDanhMucID",
                table: "DanhMuc",
                column: "LoaiDanhMucID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatHang_DatHangID",
                table: "ChiTietDatHang",
                column: "DatHangID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatHang_SanPhamID",
                table: "ChiTietDatHang",
                column: "SanPhamID");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMuc_LoaiDanhMuc_LoaiDanhMucID",
                table: "DanhMuc",
                column: "LoaiDanhMucID",
                principalTable: "LoaiDanhMuc",
                principalColumn: "LoaiDanhMucID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMuc_LoaiDanhMuc_LoaiDanhMucID",
                table: "DanhMuc");

            migrationBuilder.DropTable(
                name: "ChiTietDatHang");

            migrationBuilder.DropIndex(
                name: "IX_DanhMuc_LoaiDanhMucID",
                table: "DanhMuc");
        }
    }
}
