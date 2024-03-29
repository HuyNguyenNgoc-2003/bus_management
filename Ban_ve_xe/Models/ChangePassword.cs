﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ban_ve_xe.Models
{
    public class ChangePassword
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu cũ")]
        public string ExPassword { set; get; }

        [Display(Name = "New-Password")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Độ dài mật khẩu tối thiểu 1 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu mới")]
        public string Password { set; get; }

        [Display(Name = "Retype-Password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [Required(ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { set; get; }
    }
}