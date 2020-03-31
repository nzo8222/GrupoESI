using System;
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
    public class IndexServiceModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexServiceModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }
        public string ServiceId { get; set; }

        public async Task<IActionResult> OnGetAsync(string serviceId = null)
        {
            Order = await _context.Order
                                         .Include(o => o.Service)
                                         .Where(s => s.Id == Int32.Parse(serviceId)).ToListAsync();
            ServiceId = serviceId;
            return Page();
        }
    }
}
