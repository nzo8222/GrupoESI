using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using System.Security.Claims;

namespace GrupoESINuevo
{
    public class IndexQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderDetails> OrderDetailsLocal { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;


            OrderDetailsLocal = _context.OrderDetails
                                                     .Include(o => o.Order)
                                                     .Include(od => od.Quotation)
                                                     .Include(o => o.Service)
                                                           .ThenInclude(s => s.ApplicationUser)
                                                           .Where(od => od.Service.ApplicationUser.Id == userId).ToList();

            return Page();
        }
    }
}
