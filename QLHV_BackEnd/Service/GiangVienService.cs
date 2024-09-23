using Microsoft.EntityFrameworkCore;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.GiangVienModel;

namespace QLHV_BackEnd.Service
{
    public class GiangVienService : IGiangVienService
    {
        private readonly DBContextUser _context;
        public GiangVienService(DBContextUser context)
        {
            _context = context;
        }
        public async Task<IList<GiangVienModel>> GetGiangViens()
        {
            return await _context.GiangVien
                .Select(gv => new GiangVienModel
                {
                    GiangVienId = gv.GiangVienId,
                    HoTen = gv.HoTen,
                    NgaySinh = gv.NgaySinh,
                    ChuyenMon = gv.ChuyenMon,
                    LinkWebCaNhan = gv.LinkWebCaNhan,
                }).ToListAsync();
        }
        public async Task<IList<GiangVienModel>> Pagination(int pageSize, int pageNumber)
        {
            var skip = (pageNumber - 1) * pageSize;
            return await _context.GiangVien.Skip(skip).Take(pageSize).Select(gv => new GiangVienModel
            {
                GiangVienId = gv.GiangVienId,
                HoTen = gv.HoTen,
                NgaySinh = gv.NgaySinh,
                ChuyenMon = gv.ChuyenMon,
                LinkWebCaNhan = gv.LinkWebCaNhan,
            }).ToListAsync();
        }
        public async Task<int> CreateGiangVien(CreateGiangVienModel giangVienModel)
        {
            GiangVien giangVien = new GiangVien
            {
                HoTen = giangVienModel.HoTen,
                NgaySinh = giangVienModel.NgaySinh,
                ChuyenMon = giangVienModel.ChuyenMon,
                LinkWebCaNhan = giangVienModel.LinkWebCaNhan,
            };
            await _context.GiangVien.AddAsync(giangVien);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> UpdateGiangVien(int id, UpdateGiangVienModel giangVienModel)
        {
            var gv = await _context.GiangVien.FindAsync(id);
            if (gv == null)
            {
                return 0;
            }
            gv.LinkWebCaNhan = giangVienModel.LinkWebCaNhan;
            _context.GiangVien.Update(gv);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> DeleteGiangVien(int id)
        {
            var gv = await _context.GiangVien.FindAsync(id);
            if (gv == null)
            {
                return 0;
            }
            _context.GiangVien.Remove(gv);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }

    }
}
