using QLHV_BackEnd.Model.GiangVienModel;
using QLHV_BackEnd.Model.LichGiangDayModel;

namespace QLHV_BackEnd.Interface
{
    public interface ILichGiangDayService
    {
        Task<IList<LichGiangDayModel>> GetLichGiangDays();
        Task<int> CreateLichGiangDay(CreateLichGiangDayModel createLichGiangDayModel, string userName);
        Task<int> UpdateLichGiangDay(int id, UpdateLichGiangDayModel updateLichGiangDayModel);
        Task<int> DeleteLichGiangDay(int id);
        Task<IList<LichGiangDayModel>> Pagination(int pageSize, int pageNumber);
    }
}
