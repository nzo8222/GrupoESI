﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;

namespace GrupoESINuevo
{
    public class IndexOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderDetails> OrderDetailsList { get;set; }
        public string ServiceId { get; set; }
        //public OrderDetails OrderDetailsModel { get; set; }
        public async Task<IActionResult> OnGetAsync(string serviceId = null)
        {
            if(serviceId == null)
            {
                return Page();
            }
            //OrderDetailsModel.Service = _context.ServiceModel.FirstOrDefault(s => s.ID == Int32.Parse(serviceId));
            OrderDetailsList = await _context.OrderDetails.Include(o => o.Order).Where( s =>s.Service.ID == Int32.Parse(serviceId)).ToListAsync();
            //ServiceId = serviceId;
            return Page();
        }
    }
}
