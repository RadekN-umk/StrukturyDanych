namespace StrukturyDanych.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tool")]
    public partial class Tool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tool()
        {
            Change = new HashSet<Change>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string AlphanumericKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Change> Change { get; set; }

        public override string ToString()
        {
            return $"{AlphanumericKey}";
        }
    }
}
