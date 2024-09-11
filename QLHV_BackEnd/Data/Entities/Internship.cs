using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class Internship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternshipId { get; set; }
        public int StudentId { get; set; }
        public int CorporatePartnerId { get; set; }
        public DateTime? InternshipDate { get; set; }
        public string? Evaluation { get; set; }

        public virtual CorporatePartner CorporatePartner { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
