using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Concepto { get; set; }
        public string EstadoDelPedido { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual List<Quotation> Quotations{ get; set; }

    }
}
