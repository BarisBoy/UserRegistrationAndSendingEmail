using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UserRegistrationApp.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanını doldurmanız gereklidir.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanını doldurmanız gereklidir.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email alanını doldurmanız gereklidir.  ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçerli bir email giriniz.")]﻿
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir.")]
        public string UserName { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre Onay")]
        [Required(ErrorMessage = "Şifrenizi onaylamanız gereklidir.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Davetli Mail")]
        [Required(ErrorMessage = "Davet edeceğiniz kişinin mail adresini girmeniz gereklidir.  ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçerli bir email giriniz.")]﻿
        public string InvtEmail { get; set; }
    }
}