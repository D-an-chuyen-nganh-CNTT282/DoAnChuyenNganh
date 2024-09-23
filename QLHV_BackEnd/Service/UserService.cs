using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Helper;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.UserModel;

namespace QLHV_BackEnd.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DBContextUser _context;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, DBContextUser context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _context = context;
        }
        public async Task GetUserByEmailToRegister(string email)
        {
            ApplicationUser? user = await userManager.FindByNameAsync(email);
            if (user != null)
            {
                throw new Exception("Email đã tồn tại!");
            }
        }
        public async Task<IdentityResult> CreateUser(RegisterModel registerModel)
        {
            var newUser = new ApplicationUser
            {
                HoTen = registerModel.HoTen,
                UserName = registerModel.Email,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber
            };

            var result = await userManager.CreateAsync(newUser, registerModel.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(AppRole.GiaoVuKhoa))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRole.GiaoVuKhoa));
                }
                await userManager.AddToRoleAsync(newUser, AppRole.GiaoVuKhoa);
            }
            return result;
        }
        public async Task<int> UpdateUser(string id, UserModel userModel)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return 0;
            }
            user.HoTen = userModel.HoTen;
            user.PhoneNumber = userModel.PhoneNumber;
            _context.Users.Update(user);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return 0;
            }
            _context.Users.Remove(user);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<IList<UserModel>> GetAllUsers()
        {
            return await _context.Users
                .Select(u => new UserModel
                {
                    HoTen = u.HoTen,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                }).ToListAsync();
        }
    }
}
