using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data.Entities
{
    public class ActionNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionNotificationId { get; set; }
        public int IncomingDocumentId { get; set; }
        public DateTime Deadline { get; set; }
        public bool? NotificationSent { get; set; }

        public virtual IncomingDocuments IncomingDocument { get; set; } = null!;
    }
}
