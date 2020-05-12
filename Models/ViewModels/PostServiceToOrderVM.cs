using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class PostServiceToOrderVM
    {
        public Guid orderId { get; set; }
        public string serviceId { get; set; }
    }
}
