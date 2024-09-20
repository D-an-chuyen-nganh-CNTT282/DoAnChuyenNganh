using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class CongTy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CongTyId { get; set; }

        public required string TenCongTy { get; set; }

        public required string DiaChi { get; set; }

        public required string SoDienThoai { get; set; }

        public required string Email { get; set; }

        public required string NhanVienId { get; set; }

        //public virtual ICollection<CongTyCuuSinhVien> CongTyCuuSinhViens { get; set; } = new List<CongTyCuuSinhVien>();
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
    }
}
