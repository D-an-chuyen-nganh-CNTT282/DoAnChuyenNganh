namespace QLHV_BackEnd.Model.GiangVienModel
{
    public class GiangVienModel
    {
        public int GiangVienId { get; set; }
        public required string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public required string ChuyenMon { get; set; }
        public string? LinkWebCaNhan { get; set; } //Lưu link giáo án, bài viết,...
    }
}
