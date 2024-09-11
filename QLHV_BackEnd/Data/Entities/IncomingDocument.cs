using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entities
{
    public class IncomingDocuments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IncomingDocumentsId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime ReceivedDate { get; set; }
        public string Sender { get; set; } = null!;
        public string? Status { get; set; }
        public string? PersonInCharge { get; set; }

        public virtual ICollection<ActionNotification> ActionNotifications { get; set; } = new List<ActionNotification>();
    }
}
