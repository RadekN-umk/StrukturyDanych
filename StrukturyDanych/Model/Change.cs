namespace StrukturyDanych.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Change")]
    public partial class Change
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Change()
        {
            Tool = new HashSet<Tool>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string ChangeDescription { get; set; }

        public DateTime? ChangeDate { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tool> Tool { get; set; }

    }
}
