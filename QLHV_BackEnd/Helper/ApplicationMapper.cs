using AutoMapper;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Model.UserModel;

namespace QLHV_BackEnd.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ApplicationUser, UserModel>().ReverseMap();
        }
    }
}
