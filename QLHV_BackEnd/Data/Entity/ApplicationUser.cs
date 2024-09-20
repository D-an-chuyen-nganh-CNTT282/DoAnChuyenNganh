using Microsoft.AspNetCore.Identity;

namespace QLHV_BackEnd.Data.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public required string HoTen {  get; set; }
        public required string Email {  get; set; }
    }
}
