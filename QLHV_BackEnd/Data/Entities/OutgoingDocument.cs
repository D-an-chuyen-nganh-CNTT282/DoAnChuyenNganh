using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class OutgoingDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OutgoingDocumentId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime SentDate { get; set; }
        public string Recipient { get; set; } = null!;
        public string? ResponseStatus { get; set; }
    }
}
