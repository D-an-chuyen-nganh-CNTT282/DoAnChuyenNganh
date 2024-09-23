using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHV_BackEnd.Data.Entity
{
    public class GiangVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GiangVienId { get; set; }

        public required string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public required string ChuyenMon { get; set; }

        public string? LinkWebCaNhan { get; set; } //Lưu link giáo án, bài viết,...


        public virtual ICollection<CuuSinhVien> CuuSinhViens { get; set; } = new List<CuuSinhVien>();

        public virtual ICollection<LichGiangDay> LichGiangDays { get; set; } = new List<LichGiangDay>();

        public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();

        public virtual ICollection<SuKienHoiThaoGiangVien> SuKienHoiThaoGiangViens { get; set; } = new List<SuKienHoiThaoGiangVien>();
        public virtual ICollection<DoanhNghiep> DoanhNghieps { get; set; } = new List<DoanhNghiep>();
        public virtual ICollection<KeHoachGiangVien> KeHoachGiangViens { get; set; } = new List<KeHoachGiangVien>();
    }
}
