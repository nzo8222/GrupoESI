using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        public byte[] PictureBytes { get; set; }
    }
}
