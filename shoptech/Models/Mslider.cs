namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mslider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên hình ảnh không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }

        
        [StringLength(255)]
        public string Link { get; set; }

        [Required(ErrorMessage = "Chức vụ không được để trống")]
        [StringLength(100)]
        public string Position { get; set; }

        [Required(ErrorMessage = "File ảnh không được để trống")]
        [StringLength(100)]
        public string Img { get; set; }

        public int Orders { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}
