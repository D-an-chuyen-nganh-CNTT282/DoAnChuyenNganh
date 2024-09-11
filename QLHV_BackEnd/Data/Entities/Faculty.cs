using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }
        public string Name { get; set; } = null!;
        public string? Department { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<TeachingSchedule> TeachingSchedules { get; set; } = new List<TeachingSchedule>();
    }
}
