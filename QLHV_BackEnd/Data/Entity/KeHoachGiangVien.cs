using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class KeHoachGiangVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeHoachId { get; set; }
        public int GiangVienId { get; set; }
        public required string NoiDung {  get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc {  get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("GiangVienId")]
        public virtual GiangVien GiangVien { get; set; } = null!;
    }
}
