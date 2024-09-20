using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class CongVanDi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CongVanDiId { get; set; }

        public required string TieuDe { get; set; }

        public required string NoiDung { get; set; }

        public DateTime NgayGui { get; set; }

        public int DonViNhan { get; set; }

        public required string NhanVienId { get; set; }

        public required string TinhTrangPhanHoi { get; set; }

        public DateTime NgayHetHanPhanHoi { get; set; }
        [ForeignKey("DonViNhan")]
        public virtual PhongBan PhongBan { get; set; } = null!;
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
    }
}
