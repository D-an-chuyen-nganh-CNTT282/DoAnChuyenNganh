using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class DoanhNghiep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoanhNghiepId { get; set; }
        public int GiangVienId { get; set; }

        public required string TenDoanhNghiep { get; set; }

        public required string DiaChi { get; set; }

        public required string SoDienThoai { get; set; }

        public required string Email { get; set; }

        public required string NhanVienId { get; set; }

        public virtual ICollection<HopTacDoanhNghiep> HopTacDoanhNghieps { get; set; } = new List<HopTacDoanhNghiep>();
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
        [ForeignKey("GiangVienId")]
        public virtual GiangVien GiangVien { get; set; } = null!;

        public virtual ICollection<QuanLyThucTap> QuanLyThucTaps { get; set; } = new List<QuanLyThucTap>();

        public virtual ICollection<SuKienDoanhNghiep> SuKienDoanhNghieps { get; set; } = new List<SuKienDoanhNghiep>();
        
    }
}
