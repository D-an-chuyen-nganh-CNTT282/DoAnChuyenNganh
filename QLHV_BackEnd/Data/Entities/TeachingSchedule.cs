using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class TeachingSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeachingScheduleId { get; set; }
        public int FacultyId { get; set; }
        public string? Course { get; set; }
        public string? Semester { get; set; }
        public DateTime? TeachingDate { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
    }
}
