namespace StrukturyDanych.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductLastDateView")]
    public partial class ProductLastDateView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string AlphanumericKey { get; set; }

        public DateTime? LastDate { get; set; }

        public int? ChangeCount { get; set; }
    }
}
