using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entities
{
    public class CorporatePartner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CorporatePartnerId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Internship> Internships { get; set; } = new List<Internship>();
    }
}
