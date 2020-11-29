namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorAttributeValue")]
    public partial class VendorAttributeValue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

        public int VendorAttributeId { get; set; }

        public virtual VendorAttribute VendorAttribute { get; set; }
    }
}
