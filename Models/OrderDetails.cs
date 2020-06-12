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
        public virtual Quotation Quotation { get; set; }
        public int Status { get; set; }
        public double Cost { get; set; }
        public OrderDetails()
        {
            Service = new Service();
            Order = new Order();
        }
    }
}
