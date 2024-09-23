namespace QLHV_BackEnd.Model.GiangVienModel
{
    public class CreateGiangVienModel
    {
        public required string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public required string ChuyenMon { get; set; }

        public required string KeHoachGiangDay { get; set; }

        public required string KeHoachNghienCuu { get; set; }

        public required string CongTac { get; set; }
        public string? LinkWebCaNhan { get; set; }
    }
}
