using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLHV_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class fixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    GiangVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkWebCaNhan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.GiangVienId);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    PhongBanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.PhongBanId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachGiangVien",
                columns: table => new
                {
                    KeHoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiangVienId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachGiangVien", x => x.KeHoachId);
                    table.ForeignKey(
                        name: "FK_KeHoachGiangVien_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganhHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LopHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiemTB = table.Column<float>(type: "real", nullable: false),
                    GiangVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.SinhVienId);
                    table.ForeignKey(
                        name: "FK_SinhVien_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuKienHoiThaoGiangVien",
                columns: table => new
                {
                    SuKienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiangVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKienHoiThaoGiangVien", x => x.SuKienId);
                    table.ForeignKey(
                        name: "FK_SuKienHoiThaoGiangVien_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongTy",
                columns: table => new
                {
                    CongTyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTy", x => x.CongTyId);
                    table.ForeignKey(
                        name: "FK_CongTy_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongVanDen",
                columns: table => new
                {
                    CongVanDenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonViGui = table.Column<int>(type: "int", nullable: false),
                    FileScanUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrangXuLy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayHetHanXuLy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongVanDen", x => x.CongVanDenId);
                    table.ForeignKey(
                        name: "FK_CongVanDen_PhongBan_DonViGui",
                        column: x => x.DonViGui,
                        principalTable: "PhongBan",
                        principalColumn: "PhongBanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongVanDen_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongVanDi",
                columns: table => new
                {
                    CongVanDiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonViNhan = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TinhTrangPhanHoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHetHanPhanHoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongVanDi", x => x.CongVanDiId);
                    table.ForeignKey(
                        name: "FK_CongVanDi_PhongBan_DonViNhan",
                        column: x => x.DonViNhan,
                        principalTable: "PhongBan",
                        principalColumn: "PhongBanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongVanDi_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuuSinhVien",
                columns: table => new
                {
                    CuuSinhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganhHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LopHocTruocDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTotNghiep = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiangVienChuNhiemId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuuSinhVien", x => x.CuuSinhVienId);
                    table.ForeignKey(
                        name: "FK_CuuSinhVien_GiangVien_GiangVienChuNhiemId",
                        column: x => x.GiangVienChuNhiemId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuuSinhVien_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep",
                columns: table => new
                {
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiangVienId = table.Column<int>(type: "int", nullable: false),
                    TenDoanhNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiep", x => x.DoanhNghiepId);
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichGiangDay",
                columns: table => new
                {
                    LichId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiangVienId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TietHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichGiangDay", x => x.LichId);
                    table.ForeignKey(
                        name: "FK_LichGiangDay_GiangVien_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichGiangDay_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoatDongNgoaiKhoa",
                columns: table => new
                {
                    HoatDongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    TenHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoatDongNgoaiKhoa", x => x.HoatDongId);
                    table.ForeignKey(
                        name: "FK_HoatDongNgoaiKhoa_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YeuCauSinhVien",
                columns: table => new
                {
                    YeuCauId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    LoaiYeuCau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TinhTrangXuLy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGuiYeuCau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHoanTat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileScanUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCauSinhVien", x => x.YeuCauId);
                    table.ForeignKey(
                        name: "FK_YeuCauSinhVien_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YeuCauSinhVien_User_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongTyCuuSinhVien",
                columns: table => new
                {
                    CuuSinhVienId = table.Column<int>(type: "int", nullable: false),
                    CongTyId = table.Column<int>(type: "int", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTyCuuSinhVien", x => new { x.CuuSinhVienId, x.CongTyId });
                    table.ForeignKey(
                        name: "FK_CongTyCuuSinhVien_CongTy_CongTyId",
                        column: x => x.CongTyId,
                        principalTable: "CongTy",
                        principalColumn: "CongTyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTyCuuSinhVien_CuuSinhVien_CuuSinhVienId",
                        column: x => x.CuuSinhVienId,
                        principalTable: "CuuSinhVien",
                        principalColumn: "CuuSinhVienId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoatDongCuuSinhVien",
                columns: table => new
                {
                    HoatDongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuuSinhVienId = table.Column<int>(type: "int", nullable: false),
                    TenHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoatDongCuuSinhVien", x => x.HoatDongId);
                    table.ForeignKey(
                        name: "FK_HoatDongCuuSinhVien_CuuSinhVien_CuuSinhVienId",
                        column: x => x.CuuSinhVienId,
                        principalTable: "CuuSinhVien",
                        principalColumn: "CuuSinhVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopTacDoanhNghiep",
                columns: table => new
                {
                    HopTacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrangDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KetQuaHopTac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopTacDoanhNghiep", x => x.HopTacId);
                    table.ForeignKey(
                        name: "FK_HopTacDoanhNghiep_DoanhNghiep_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghiep",
                        principalColumn: "DoanhNghiepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyThucTap",
                columns: table => new
                {
                    ThucTapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyThucTap", x => x.ThucTapId);
                    table.ForeignKey(
                        name: "FK_QuanLyThucTap_DoanhNghiep_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghiep",
                        principalColumn: "DoanhNghiepId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanLyThucTap_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuKienDoanhNghiep",
                columns: table => new
                {
                    SuKienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKienDoanhNghiep", x => x.SuKienId);
                    table.ForeignKey(
                        name: "FK_SuKienDoanhNghiep_DoanhNghiep_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghiep",
                        principalColumn: "DoanhNghiepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongTy_NhanVienId",
                table: "CongTy",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CongTyCuuSinhVien_CongTyId",
                table: "CongTyCuuSinhVien",
                column: "CongTyId");

            migrationBuilder.CreateIndex(
                name: "IX_CongVanDen_DonViGui",
                table: "CongVanDen",
                column: "DonViGui");

            migrationBuilder.CreateIndex(
                name: "IX_CongVanDen_NhanVienId",
                table: "CongVanDen",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CongVanDi_DonViNhan",
                table: "CongVanDi",
                column: "DonViNhan");

            migrationBuilder.CreateIndex(
                name: "IX_CongVanDi_NhanVienId",
                table: "CongVanDi",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CuuSinhVien_GiangVienChuNhiemId",
                table: "CuuSinhVien",
                column: "GiangVienChuNhiemId");

            migrationBuilder.CreateIndex(
                name: "IX_CuuSinhVien_NhanVienId",
                table: "CuuSinhVien",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_GiangVienId",
                table: "DoanhNghiep",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_NhanVienId",
                table: "DoanhNghiep",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoatDongCuuSinhVien_CuuSinhVienId",
                table: "HoatDongCuuSinhVien",
                column: "CuuSinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoatDongNgoaiKhoa_SinhVienId",
                table: "HoatDongNgoaiKhoa",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HopTacDoanhNghiep_DoanhNghiepId",
                table: "HopTacDoanhNghiep",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachGiangVien_GiangVienId",
                table: "KeHoachGiangVien",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LichGiangDay_GiangVienId",
                table: "LichGiangDay",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LichGiangDay_NhanVienId",
                table: "LichGiangDay",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyThucTap_DoanhNghiepId",
                table: "QuanLyThucTap",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyThucTap_SinhVienId",
                table: "QuanLyThucTap",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_GiangVienId",
                table: "SinhVien",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_SuKienDoanhNghiep_DoanhNghiepId",
                table: "SuKienDoanhNghiep",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_SuKienHoiThaoGiangVien_GiangVienId",
                table: "SuKienHoiThaoGiangVien",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSinhVien_NhanVienId",
                table: "YeuCauSinhVien",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauSinhVien_SinhVienId",
                table: "YeuCauSinhVien",
                column: "SinhVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongTyCuuSinhVien");

            migrationBuilder.DropTable(
                name: "CongVanDen");

            migrationBuilder.DropTable(
                name: "CongVanDi");

            migrationBuilder.DropTable(
                name: "HoatDongCuuSinhVien");

            migrationBuilder.DropTable(
                name: "HoatDongNgoaiKhoa");

            migrationBuilder.DropTable(
                name: "HopTacDoanhNghiep");

            migrationBuilder.DropTable(
                name: "KeHoachGiangVien");

            migrationBuilder.DropTable(
                name: "LichGiangDay");

            migrationBuilder.DropTable(
                name: "QuanLyThucTap");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SuKienDoanhNghiep");

            migrationBuilder.DropTable(
                name: "SuKienHoiThaoGiangVien");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "YeuCauSinhVien");

            migrationBuilder.DropTable(
                name: "CongTy");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "CuuSinhVien");

            migrationBuilder.DropTable(
                name: "DoanhNghiep");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "GiangVien");
        }
    }
}
