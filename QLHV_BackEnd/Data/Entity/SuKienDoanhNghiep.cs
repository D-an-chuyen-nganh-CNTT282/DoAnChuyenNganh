using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class SuKienDoanhNghiep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuKienId { get; set; }

        public required string TenSuKien { get; set; }

        public DateTime NgayToChuc { get; set; }

        public required string DiaDiem { get; set; }

        public string? MoTa { get; set; }

        public int DoanhNghiepId { get; set; }
        [ForeignKey("DoanhNghiepId")]
        public virtual DoanhNghiep DoanhNghiep { get; set; } = null!;
    }
}
