namespace RoofrackDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryTemplate")]
    public partial class CategoryTemplate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [Required]
        [StringLength(400)]
        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
