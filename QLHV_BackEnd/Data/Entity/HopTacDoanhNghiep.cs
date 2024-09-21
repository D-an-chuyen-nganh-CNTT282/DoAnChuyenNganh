using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class HopTacDoanhNghiep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HopTacId { get; set; }

        public int DoanhNghiepId { get; set; }

        public required string TenDuAn { get; set; }

        public required string TinhTrangDuAn { get; set; }

        public string? KetQuaHopTac { get; set; }
        [ForeignKey("DoanhNghiepId")]

        public virtual DoanhNghiep DoanhNghiep { get; set; } = null!;
    }
}
