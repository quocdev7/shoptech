namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mcontact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Họ tên không được để trống")]
        [StringLength(64)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(64)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Detail { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        public int? Created_by { get; set; }
        [Required]
        public int? Status { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
