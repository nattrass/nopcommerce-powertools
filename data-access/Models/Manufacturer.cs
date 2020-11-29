namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manufacturer")]
    public partial class Manufacturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacturer()
        {
            Product_Manufacturer_Mapping = new HashSet<Product_Manufacturer_Mapping>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ManufacturerTemplateId { get; set; }

        [StringLength(400)]
        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(400)]
        public string MetaTitle { get; set; }

        public int PictureId { get; set; }

        public int PageSize { get; set; }

        public bool AllowCustomersToSelectPageSize { get; set; }

        [StringLength(200)]
        public string PageSizeOptions { get; set; }

        [StringLength(400)]
        public string PriceRanges { get; set; }

        public bool SubjectToAcl { get; set; }

        public bool LimitedToStores { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOnUtc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOnUtc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Manufacturer_Mapping> Product_Manufacturer_Mapping { get; set; }
    }
}
