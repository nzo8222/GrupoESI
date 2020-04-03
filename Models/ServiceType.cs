using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Descripcion { get; set; }
    }
}
