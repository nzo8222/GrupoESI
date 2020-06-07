using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Picture
    {
        [Key]
        public Guid PictureId { get; set; }
        public byte[] PictureBytes { get; set; }

        [ForeignKey("TaskModel")]
        public Guid TaskModelId { get; set; }
    }
}
