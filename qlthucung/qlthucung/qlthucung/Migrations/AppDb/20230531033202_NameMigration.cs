using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace qlthucung.Migrations.AppDb
{
    public partial class NameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    idDanhmuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendanhmuc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ParentID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhMuc__DB790BF68C813DE1", x => x.idDanhmuc);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__8AFACE3A2B34BEF9", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ThuVienAnh",
                columns: table => new
                {
                    idthuvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    img1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    img2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    img3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThuVienA__31FA4CDF3B21DD43", x => x.idthuvien);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    makh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tendangnhap = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    matkhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dienthoai = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    resetpasswordcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__7A21BB4CE42C9226", x => x.makh);
                    table.ForeignKey(
                        name: "FK__KhachHang__RoleI__2E1BDC42",
                        column: x => x.RoleID,
                        principalTable: "KhachHangRoles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    masp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDanhmuc = table.Column<int>(type: "int", nullable: true),
                    idthuvien = table.Column<int>(type: "int", nullable: true),
                    tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    giaban = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ngaycapnhat = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    soluongton = table.Column<int>(type: "int", nullable: true),
                    mota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    giamgia = table.Column<int>(type: "int", nullable: true),
                    giakhuyenmai = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__7A217672AEC9D6C2", x => x.masp);
                    table.ForeignKey(
                        name: "FK__SanPham__idDanhm__286302EC",
                        column: x => x.idDanhmuc,
                        principalTable: "DanhMuc",
                        principalColumn: "idDanhmuc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SanPham__idthuvi__29572725",
                        column: x => x.idthuvien,
                        principalTable: "ThuVienAnh",
                        principalColumn: "idthuvien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    iddichvu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    trangthai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    tendichvu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ngaydat = table.Column<DateTime>(type: "datetime", nullable: true),
                    makh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DichVu__77FDDBF8BC48DDF1", x => x.iddichvu);
                    table.ForeignKey(
                        name: "FK__DichVu__makh__30F848ED",
                        column: x => x.makh,
                        principalTable: "KhachHang",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    madon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    thanhtoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    giaohang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngaydat = table.Column<DateTime>(type: "date", nullable: true),
                    ngaygiao = table.Column<DateTime>(type: "date", nullable: true),
                    makh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DonHang__0BE416770A34913A", x => x.madon);
                    table.ForeignKey(
                        name: "FK__DonHang__makh__33D4B598",
                        column: x => x.makh,
                        principalTable: "KhachHang",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Ngaycapnhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    id_sp = table.Column<int>(type: "int", nullable: true),
                    id_kh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DanhGia__id_kh__3C69FB99",
                        column: x => x.id_kh,
                        principalTable: "KhachHang",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DanhGia__id_sp__3B75D760",
                        column: x => x.id_sp,
                        principalTable: "SanPham",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    madon = table.Column<int>(type: "int", nullable: false),
                    masp = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: true),
                    gia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    tongsoluong = table.Column<int>(type: "int", nullable: true),
                    tonggia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietD__3C460110D46F34D2", x => new { x.madon, x.masp });
                    table.ForeignKey(
                        name: "FK__ChiTietDo__madon__36B12243",
                        column: x => x.madon,
                        principalTable: "DonHang",
                        principalColumn: "madon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ChiTietDon__masp__37A5467C",
                        column: x => x.masp,
                        principalTable: "SanPham",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_masp",
                table: "ChiTietDonHang",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_id_kh",
                table: "DanhGia",
                column: "id_kh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_id_sp",
                table: "DanhGia",
                column: "id_sp");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_makh",
                table: "DichVu",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_makh",
                table: "DonHang",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_RoleID",
                table: "KhachHang",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_idDanhmuc",
                table: "SanPham",
                column: "idDanhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_idthuvien",
                table: "SanPham",
                column: "idthuvien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "ThuVienAnh");

            migrationBuilder.DropTable(
                name: "KhachHangRoles");
        }
    }
}
