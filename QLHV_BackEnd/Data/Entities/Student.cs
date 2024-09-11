using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Class { get; set; }
        public string? Major { get; set; }
        public string? AcademicStatus { get; set; }

        public virtual ICollection<Internship> Internships { get; set; } = new List<Internship>();
        public virtual ICollection<StudentRequest> StudentRequests { get; set; } = new List<StudentRequest>();
    }
}
