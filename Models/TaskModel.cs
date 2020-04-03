using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public virtual List<Material> ListMaterial { get; set; }
    }
}
