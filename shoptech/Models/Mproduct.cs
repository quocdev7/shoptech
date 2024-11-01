namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mproduct
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        public int CatId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }

        
        [StringLength(255)]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [StringLength(100)]
        public string Img { get; set; }

        
        public string Detail { get; set; }

        [Required(ErrorMessage = "Só lượng không được để trống")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Giá tiền không được để trống")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Số tiền giảm giá không được để trống")]
        public double Price_sale { get; set; }

        [Required(ErrorMessage = "Từ khóa không được để trống")]
        [StringLength(155)]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(155)]
        public string MetaDesc { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        [Required]
        public int? Status { get; set; }
    }
}
