using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class LichGiangDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LichId { get; set; }

        public int GiangVienId { get; set; }

        public required string NhanVienId { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public required string MonHoc { get; set; }

        public required string DiaDiem { get; set; }
        public required string TietHoc { get; set; }

        public virtual GiangVien GiangVien { get; set; } = null!;
        [ForeignKey("NhanVienId")]
        public ApplicationUser NhanVien { get; set; }
    }
}
