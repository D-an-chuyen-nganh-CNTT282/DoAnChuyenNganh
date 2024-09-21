using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class HoatDongCuuSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoatDongId { get; set; }

        public int CuuSinhVienId { get; set; }

        public required string TenHoatDong { get; set; }

        public DateTime NgayToChuc { get; set; }
        [ForeignKey("CuuSinhVienId")]
        public virtual CuuSinhVien CuuSinhVien { get; set; } = null!;
    }
}
