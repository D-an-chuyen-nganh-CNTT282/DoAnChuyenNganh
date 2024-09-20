using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class CongTyCuuSinhVien
    {
        [Key, Column(Order = 1)]
        public int CuuSinhVienId { get; set; }

        [Key, Column(Order = 2)]
        public int CongTyId { get; set; }

        public string? ChucVu { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        [ForeignKey("CongTyId")]
        public virtual CongTy CongTy { get; set; } = null!;

        [ForeignKey("CuuSinhVienId")]
        public virtual CuuSinhVien CuuSinhVien { get; set; } = null!;
    }
}
