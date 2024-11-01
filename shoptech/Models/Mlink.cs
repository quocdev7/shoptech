using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopdodadung.Models
{
    [Table("Links")]
    public class Mlink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Slug { get; set; }
        public int TableId { get; set; }
        [Required]
        public String Types { get; set; }
    }
}