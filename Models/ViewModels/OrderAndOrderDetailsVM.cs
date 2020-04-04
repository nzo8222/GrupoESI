using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class OrderAndOrderDetailsVM
    {
        public Order OrderModel { get; set; }
        public OrderDetails OrderDetailsModel { get; set; }
        public string serviceIdVM { get; set; }
    }
}
