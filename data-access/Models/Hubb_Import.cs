using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoofrackDataAccess.Models
{
    public class Hubb_Import
    {
        [Key]
        [Column("PRODUCT", Order = 1)]
        public string PRODUCT { get; set; }
        [Key]
        [Column("VEHICLE", Order = 2)]
        public string VEHICLE { get; set; }
        [Key]
        [Column("WHEELBASE", Order = 3)]
        public string WHEELBASE { get; set; }
        [Key]
        [Column("ROOF_HEIGHT", Order = 4)]
        public string ROOF_HEIGHT { get; set; }
        [Key]
        [Column("DOORS", Order = 5)]
        public string DOORS { get; set; }
        [Key]
        [Column("PRODUCT_CODE", Order = 6)]
        public string PRODUCT_CODE { get; set; }
        [Key]
        [Column("PRODUCT_DESCRIPTION", Order = 7)]
        public string PRODUCT_DESCRIPTION { get; set; }
        [Key]
        [Column("HELPFUL_INFORMATION", Order = 8)]
        public string HELPFUL_INFORMATION { get; set; }
        [Key]
        [Column("FIT_TIMES_1", Order = 9)]
        public float? FIT_TIMES_1 { get; set; }
        [Key]
        [Column("FIT_TIMES_2", Order = 10)]
        public float? FIT_TIMES_2 { get; set; }
        [Key]
        [Column("WEIGHT", Order = 11)]
        public string WEIGHT { get; set; }
        [Key]
        [Column("RRP", Order = 12)]
        public decimal? RRP { get; set; }
        [Key]
        [Column("QTY", Order = 13)]
        public string QTY { get; set; }
        [Key]
        [Column("NOTES", Order = 14)]
        public string NOTES { get; set; }
    }
}
