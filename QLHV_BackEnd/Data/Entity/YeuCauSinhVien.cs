using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class YeuCauSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YeuCauId { get; set; }

        public int SinhVienId { get; set; }

        public required string LoaiYeuCau { get; set; }

        public required string NhanVienId { get; set; }

        public required string TinhTrangXuLy { get; set; }

        public DateTime NgayGuiYeuCau { get; set; }

        public DateTime NgayHoanTat { get; set; }
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }

        public virtual SinhVien SinhVien { get; set; } = null!;
    }
}
