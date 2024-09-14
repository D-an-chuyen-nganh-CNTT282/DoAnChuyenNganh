namespace QLHV_BackEnd.Models
{
    public class CreateIncomingDocumentModel
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime ReceivedDate { get; set; }
        public string Sender { get; set; } = null!;
        public string? Status { get; set; }
        public string? PersonInCharge { get; set; }
    }
}
