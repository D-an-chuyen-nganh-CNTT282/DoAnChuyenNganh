using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class CongVanDen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CongVanDenId { get; set; }

        public required string TieuDe { get; set; }

        public required string NoiDung { get; set; }

        public DateTime NgayNhan { get; set; }

        public int DonViGui { get; set; }

        public required string FileScanUrl { get; set; }

        public required string TinhTrangXuLy { get; set; }

        public required string NhanVienId { get; set; }

        public DateTime NgayHetHanXuLy { get; set; }
        [ForeignKey("DonViGui")]
        public virtual PhongBan PhongBan { get; set; } = null!;
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
    }
}
