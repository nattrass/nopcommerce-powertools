namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorAttribute")]
    public partial class VendorAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorAttribute()
        {
            VendorAttributeValues = new HashSet<VendorAttributeValue>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        public bool IsRequired { get; set; }

        public int DisplayOrder { get; set; }

        public int AttributeControlTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorAttributeValue> VendorAttributeValues { get; set; }
    }
}
