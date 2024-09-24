namespace QLHV_BackEnd.Model.LichGiangDayModel
{
    public class CreateLichGiangDayModel
    {

        public int GiangVienId { get; set; }
        public required string NhanVienId { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public required string MonHoc { get; set; }

        public required string DiaDiem { get; set; }
        public required string TietHoc { get; set; }
    }
}
