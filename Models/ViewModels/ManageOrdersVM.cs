﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class ManageOrdersVM
    {
        public Order OrderModel { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; }
        public List<Quotation> ListQuotations { get; set; }
        public List<Service> ListServices { get; set; }
    }
}
