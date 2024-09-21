using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class HoatDongNgoaiKhoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoatDongId { get; set; }

        public int SinhVienId { get; set; }

        public required string TenHoatDong { get; set; }

        public DateTime NgayToChuc { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;
    }
}
