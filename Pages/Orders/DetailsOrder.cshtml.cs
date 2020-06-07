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
    public class DetailsOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DetailsOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                                        .FirstOrDefaultAsync(m => m.Id == orderId);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
