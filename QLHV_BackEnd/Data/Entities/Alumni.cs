using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entities
{
    public class Alumni
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlumniId { get; set; }
        public string Name { get; set; } = null!;
        public string Major {  get; set; }
        public string Course { get; set; }
        public string? CurrentJob { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
