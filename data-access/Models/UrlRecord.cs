using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoofrackDataAccess.Models
{
    [Table("UrlRecord")]
    public class UrlRecord
    {
        [Key]
        [Column("Id", Order = 1)]
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
    }
}
