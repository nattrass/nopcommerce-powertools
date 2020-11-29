namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendor")]
    public partial class Vendor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Email { get; set; }

        public string Description { get; set; }

        public int PictureId { get; set; }

        public int AddressId { get; set; }

        public string AdminComment { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(400)]
        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(400)]
        public string MetaTitle { get; set; }

        public int PageSize { get; set; }

        public bool AllowCustomersToSelectPageSize { get; set; }

        [StringLength(200)]
        public string PageSizeOptions { get; set; }
    }
}
