namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mmenu")]
    public partial class Mmenu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        [StringLength(255)]
        public string Link { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        
        public int? TableId { get; set; }

        [Required]
        public int? Orders { get; set; }

        public DateTime? Created_at { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        [Required]
        public int? Status { get; set; }

        [Required]
        public String Position { get; set; }

    }
}
