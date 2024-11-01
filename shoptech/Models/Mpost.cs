namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mpost
    {
        public int Id { get; set; }

        public int? CatId { get; set; }

        [Required(ErrorMessage = "Tên bài viết không được để trống")]
        [StringLength(255)]
        public string Title { get; set; }

        
        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Mô tả bài viết không được để trống")]
        public string Detail { get; set; }

        [Required]
        [StringLength(100)]
        public string Img { get; set; }

        [StringLength(155)]
        public string MetaKey { get; set; }

        [StringLength(155)]
        public string MetaDesc { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        public int? Status { get; set; }
    }
}
