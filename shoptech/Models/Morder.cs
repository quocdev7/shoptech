namespace shopdodadung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Morder
    {
        public int Id { get; set; }

        public int CustemerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExportDate { get; set; }

        [StringLength(255)]
        public string DeliveryAddress { get; set; }

        [StringLength(255)]
        public string DeliveryName { get; set; }

        public int? Status { get; set; }
    }
}
