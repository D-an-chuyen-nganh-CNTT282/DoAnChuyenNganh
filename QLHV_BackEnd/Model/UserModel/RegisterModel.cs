﻿using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Model.UserModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.])[A-Za-z\d@$!%*?&.]{8,16}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt")]
        public string Password { get; set; }
    }
}
