namespace QLHV_BackEnd.Data.Entities
{
    public class StudentRequest
    {
        public int StudentRequestId { get; set; }
        public int StudentId { get; set; }
        public string? RequestType { get; set; }
        public string? ProcessingStatus { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
