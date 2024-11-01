namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mcategogys")]
    public partial class Mcategogy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Slug { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public int? Orders { get; set; }

        [Required(ErrorMessage = "Từ khóa(SEO) không được để trống")]
        [StringLength(255)]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Mô tả(SEO) không được để trống")]
        [StringLength(255)]
        public string MetaDesc { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        [Required]
        public int? Status { get; set; }
    }
}
