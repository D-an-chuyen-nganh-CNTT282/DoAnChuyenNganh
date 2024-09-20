using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class CuuSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuuSinhVienId { get; set; }

        public required string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public required string DiaChi { get; set; }

        public required string Email { get; set; }

        public required string NganhHoc { get; set; }

        public required string KhoaHoc { get; set; }

        public required string LopHocTruocDay { get; set; }

        public DateTime NgayTotNghiep { get; set; }

        public int GiangVienChuNhiemId { get; set; }

        public required string NhanVienId { get; set; }

        //public virtual ICollection<CongTyCuuSinhVien> CongTyCuuSinhViens { get; set; } = new List<CongTyCuuSinhVien>();

        public virtual GiangVien GiangVienChuNhiem { get; set; } = null!;

        public virtual ICollection<HoatDongCuuSinhVien> HoatDongCuuSinhViens { get; set; } = new List<HoatDongCuuSinhVien>();
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
    }
}
