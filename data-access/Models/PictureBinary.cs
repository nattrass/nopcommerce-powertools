using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoofrackDataAccess.Models
{
    [Table("PictureBinary")]
    public class PictureBinary
    {
        public int Id { get; set; }
        public byte[] BinaryData { get; set; }
        public int PictureId { get; set; }
    }
}
