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
    public class DetailsServiceModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DetailsServiceModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ServiceModel ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceModel = await _context.ServiceModel
                .Include(s => s.ApplicationUser).FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
