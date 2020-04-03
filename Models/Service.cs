using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ServiceType serviceType { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
