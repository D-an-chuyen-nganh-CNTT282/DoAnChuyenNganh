using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class QuanLyThucTap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThucTapId { get; set; }

        public int SinhVienId { get; set; }

        public int DoanhNghiepId { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public required string DanhGia { get; set; }

        public virtual DoanhNghiep DoanhNghiep { get; set; } = null!;

        public virtual SinhVien SinhVien { get; set; } = null!;
    }
}
