namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_ProductAttribute_Mapping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_ProductAttribute_Mapping()
        {
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductAttributeId { get; set; }

        public string TextPrompt { get; set; }

        public bool IsRequired { get; set; }

        public int AttributeControlTypeId { get; set; }

        public int DisplayOrder { get; set; }

        public int? ValidationMinLength { get; set; }

        public int? ValidationMaxLength { get; set; }

        public string ValidationFileAllowedExtensions { get; set; }

        public int? ValidationFileMaximumSize { get; set; }

        public string DefaultValue { get; set; }

        public string ConditionAttributeXml { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
