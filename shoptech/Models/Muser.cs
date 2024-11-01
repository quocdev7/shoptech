namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Muser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(40)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public bool? Gender { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Img { get; set; }

        public int Access { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}
