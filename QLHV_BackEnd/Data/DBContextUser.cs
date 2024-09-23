using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QLHV_BackEnd.Data.Entity;
using System.Reflection.Emit;

namespace QLHV_BackEnd.Data
{
    public class DBContextUser : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<CongTy> CongTy { get; set; }
        public DbSet<CongTyCuuSinhVien> CongTyCuuSinhVien { get; set; }
        public DbSet<CongVanDen> CongVanDen { get; set; }
        public DbSet<CongVanDi> CongVanDi { get; set; }
        public DbSet<CuuSinhVien> CuuSinhVien { get; set; }
        public DbSet<DoanhNghiep> DoanhNghiep { get; set; }
        public DbSet<GiangVien> GiangVien { get; set; }
        public DbSet<HoatDongCuuSinhVien> HoatDongCuuSinhVien { get; set; }
        public DbSet<HoatDongNgoaiKhoa> HoatDongNgoaiKhoa { get; set; }
        public DbSet<HopTacDoanhNghiep> HopTacDoanhNghiep { get; set; }
        public DbSet<LichGiangDay> LichGiangDay { get; set; }
        public DbSet<QuanLyThucTap> QuanLyThucTap { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<SuKienDoanhNghiep> SuKienDoanhNghiep { get; set; }
        public DbSet<SuKienHoiThaoGiangVien> SuKienHoiThaoGiangVien { get; set; }
        public DbSet<YeuCauSinhVien> YeuCauSinhVien { get; set; }
        public DbSet<KeHoachGiangVien> KeHoachGiangVien { get; set; }
        public DBContextUser(DbContextOptions<DBContextUser> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /// Khởi tạo tbl
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");


            builder.Entity<CongTy>();
            builder.Entity<CongTyCuuSinhVien>();
            builder.Entity<CongVanDen>();
            builder.Entity<CongVanDi>();
            builder.Entity<CuuSinhVien>();
            builder.Entity<DoanhNghiep>();
            builder.Entity<GiangVien>();
            builder.Entity<HoatDongCuuSinhVien>();
            builder.Entity<HoatDongNgoaiKhoa>();
            builder.Entity<HopTacDoanhNghiep>();
            builder.Entity<LichGiangDay>();
            builder.Entity<PhongBan>();
            builder.Entity<QuanLyThucTap>();
            builder.Entity<SinhVien>();
            builder.Entity<SuKienDoanhNghiep>();
            builder.Entity<SuKienHoiThaoGiangVien>();
            builder.Entity<YeuCauSinhVien>();
            builder.Entity<KeHoachGiangVien>();

            // Cấu hình khóa chính tổng hợp cho CongTyCuuSinhVien
            builder.Entity<CongTyCuuSinhVien>()
                .HasKey(cs => new { cs.CuuSinhVienId, cs.CongTyId });

            // Cấu hình quan hệ với CuuSinhVien
            builder.Entity<CongTyCuuSinhVien>()
                .HasOne(cs => cs.CuuSinhVien)
                .WithMany() // Không cần thuộc tính điều hướng ngược lại trong CuuSinhVien
                .HasForeignKey(cs => cs.CuuSinhVienId)
                .OnDelete(DeleteBehavior.Restrict); // Tránh cascade xóa gây ra nhiều đường dẫn cascade

            // Cấu hình quan hệ với CongTy
            builder.Entity<CongTyCuuSinhVien>()
                .HasOne(cs => cs.CongTy)
                .WithMany() // Không cần thuộc tính điều hướng ngược lại trong CongTy
                .HasForeignKey(cs => cs.CongTyId)
                .OnDelete(DeleteBehavior.Restrict); // Tránh cascade xóa gây ra nhiều đường dẫn cascade
                                                    // Quan hệ với bảng SinhVien
            builder.Entity<QuanLyThucTap>()
                .HasOne(q => q.SinhVien)
                .WithMany(s => s.QuanLyThucTaps)
                .HasForeignKey(q => q.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.NoAction

            // Quan hệ với bảng DoanhNghiep
            builder.Entity<QuanLyThucTap>()
                .HasOne(q => q.DoanhNghiep)
                .WithMany(d => d.QuanLyThucTaps)
                .HasForeignKey(q => q.DoanhNghiepId)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.NoAction
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
