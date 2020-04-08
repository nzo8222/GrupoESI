using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class OrderDetails
    {
        [Key]
        public Guid Id { get; set; }
        public Service Service { get; set; }
        public Order Order { get; set; }
        public double Cost { get; set; }
    }
}
