namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAttributeValue")]
    public partial class ProductAttributeValue
    {
        public int Id { get; set; }

        public int ProductAttributeMappingId { get; set; }

        public int AttributeValueTypeId { get; set; }

        public int AssociatedProductId { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ColorSquaresRgb { get; set; }

        public int ImageSquaresPictureId { get; set; }

        public decimal PriceAdjustment { get; set; }

        public bool PriceAdjustmentUsePercentage { get; set; }

        public decimal WeightAdjustment { get; set; }

        public decimal Cost { get; set; }

        public bool CustomerEntersQty { get; set; }

        public int Quantity { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

        public int PictureId { get; set; }

        public virtual Product_ProductAttribute_Mapping Product_ProductAttribute_Mapping { get; set; }
    }
}
