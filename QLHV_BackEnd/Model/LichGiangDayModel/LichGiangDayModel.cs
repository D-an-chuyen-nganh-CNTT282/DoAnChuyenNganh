namespace QLHV_BackEnd.Model.LichGiangDayModel
{
    public class LichGiangDayModel
    {
        public int LichId { get; set; }

        public string HoTen { get; set; }

        public required string NhanVien { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public required string MonHoc { get; set; }

        public required string DiaDiem { get; set; }

        public required string TietHoc { get; set; }
    }
}
