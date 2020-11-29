using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoofrackDataAccess.Models
{
    [Table("Picture")]
    public class Picture
    {
        public int Id { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool IsNew { get; set; }
        public string VirtualPath { get; set; }
    }
}
