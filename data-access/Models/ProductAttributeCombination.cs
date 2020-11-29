namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAttributeCombination")]
    public partial class ProductAttributeCombination
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string AttributesXml { get; set; }

        public int StockQuantity { get; set; }

        public bool AllowOutOfStockOrders { get; set; }

        [StringLength(400)]
        public string Sku { get; set; }

        [StringLength(400)]
        public string ManufacturerPartNumber { get; set; }

        [StringLength(400)]
        public string Gtin { get; set; }

        public decimal? OverriddenPrice { get; set; }

        public int NotifyAdminForQuantityBelow { get; set; }

        public int PictureId { get; set; }

        public virtual Product Product { get; set; }
    }
}
