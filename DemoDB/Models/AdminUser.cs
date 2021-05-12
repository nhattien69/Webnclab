﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AdminUser
    {
        //[Required(ErrorMessage = "ID not empty...")]
        [Display(Name ="Mã User")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name not empty...")]
        //[StringLength(50, MinimumLength = 5)]
        [Display(Name = "Tên User")]
        public string NameUser { get; set; }

        [DisplayName("Vị trí")]
        public string RoleUser { get; set; }

        [DisplayName("Nhập mật khẩu")]
        [Required(ErrorMessage = "Pass not empty ...")]
        [DataType(DataType.Password)]
        public string PasswordUser { get; set; }

        [NotMapped]
        [Compare("PasswordUser")]
        [DisplayName("Nhập lại mật khẩu")]
        public string ConfirmPass { get; set; }

        [NotMapped]
        public string ErrorLogin { get; set; }
    }
}
