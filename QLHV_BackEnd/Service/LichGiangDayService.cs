using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.LichGiangDayModel;

namespace QLHV_BackEnd.Service
{
    public class LichGiangDayService : ILichGiangDayService
    {
        public readonly DBContextUser _context;
        public readonly UserManager<ApplicationUser> userManager;
        public LichGiangDayService(DBContextUser context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        public async Task<IList<LichGiangDayModel>> GetLichGiangDays()
        {
            return await _context.LichGiangDay
                .Include(gv => gv.GiangVien)
                .Select(lgd => new LichGiangDayModel
                {
                    LichId = lgd.LichId,
                    HoTen = lgd.GiangVien.HoTen,
                    NhanVien = lgd.NhanVien.HoTen,
                    MonHoc = lgd.MonHoc,
                    DiaDiem = lgd.DiaDiem,
                    TietHoc = lgd.TietHoc,
                    NgayBatDau = lgd.NgayBatDau,
                    NgayKetThuc = lgd.NgayKetThuc
                }).ToListAsync();
        }
        public async Task<IList<LichGiangDayModel>> Pagination(int pageSize, int pageNumber)
        {
            var skip = (pageNumber - 1) * pageSize;
            return await _context.LichGiangDay.Skip(skip).Take(pageSize).Select(lgd => new LichGiangDayModel
            {
                LichId = lgd.LichId,
                HoTen = lgd.GiangVien.HoTen,
                NhanVien = lgd.NhanVien.HoTen,
                MonHoc = lgd.MonHoc,
                DiaDiem = lgd.DiaDiem,
                TietHoc = lgd.TietHoc,
                NgayBatDau = lgd.NgayBatDau,
                NgayKetThuc = lgd.NgayKetThuc
            }).ToListAsync();
        }
        public async Task<int> CreateLichGiangDay(CreateLichGiangDayModel model, string userName)
        {
            LichGiangDay lichGiangDay = new LichGiangDay
            {
                GiangVienId = model.GiangVienId,
                NhanVienId = userName,
                NgayBatDau = model.NgayBatDau,
                NgayKetThuc = model.NgayKetThuc,
                MonHoc = model.MonHoc,
                TietHoc = model.TietHoc,
                DiaDiem = model.DiaDiem,

            };
            await _context.LichGiangDay.AddAsync(lichGiangDay);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> UpdateLichGiangDay(int id, UpdateLichGiangDayModel model)
        {
            var lgd = await _context.LichGiangDay.FindAsync(id);
            if (lgd == null)
            {
                return 0;
            }
            lgd.DiaDiem = model.DiaDiem;
            lgd.TietHoc = model.TietHoc;
            _context.LichGiangDay.Update(lgd);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> DeleteLichGiangDay(int id)
        {
            var lgd = await _context.LichGiangDay.FindAsync(id);
            if (lgd == null)
            {
                return 0;
            }
            _context.LichGiangDay.Remove(lgd);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
    }
}
