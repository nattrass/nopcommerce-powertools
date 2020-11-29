namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_SpecificationAttribute_Mapping
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int AttributeTypeId { get; set; }

        public int SpecificationAttributeOptionId { get; set; }

        [StringLength(4000)]
        public string CustomValue { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnProductPage { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Product Product { get; set; }
    }
}
