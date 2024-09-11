using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
