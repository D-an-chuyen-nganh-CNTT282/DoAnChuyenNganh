using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class SinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SinhVienId { get; set; }

        public required string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public required string DiaChi { get; set; }

        public required string Email { get; set; }

        public required string NganhHoc { get; set; }

        public required string KhoaHoc { get; set; }

        public required string LopHoc { get; set; }
        public required float DiemTB { get; set; }

        public int GiangVienId { get; set; }

        public virtual GiangVien GiangVien { get; set; } = null!;

        public virtual ICollection<HoatDongNgoaiKhoa> HoatDongNgoaiKhoas { get; set; } = new List<HoatDongNgoaiKhoa>();

        public virtual ICollection<QuanLyThucTap> QuanLyThucTaps { get; set; } = new List<QuanLyThucTap>();

        public virtual ICollection<YeuCauSinhVien> YeuCauSinhViens { get; set; } = new List<YeuCauSinhVien>();
    }
}
