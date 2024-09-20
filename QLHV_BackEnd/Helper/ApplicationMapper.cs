using AutoMapper;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Model;

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
