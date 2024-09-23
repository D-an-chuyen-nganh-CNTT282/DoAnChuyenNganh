using QLHV_BackEnd.Model.GiangVienModel;

namespace QLHV_BackEnd.Interface
{
    public interface IGiangVienService
    {
        Task<IList<GiangVienModel>> GetGiangViens();
        Task<int> CreateGiangVien(CreateGiangVienModel giangVienModel);
        Task<int> UpdateGiangVien(int id, UpdateGiangVienModel giangVienModel);
        Task<int> DeleteGiangVien(int id);
        Task<IList<GiangVienModel>> Pagination(int pageSize, int pageNumber);
    }
}
