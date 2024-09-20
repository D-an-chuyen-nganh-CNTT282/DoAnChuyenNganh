using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entity
{
    public class PhongBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhongBanId { get; set; }
        public required string TenPhongBan {  get; set; }
    }
}
