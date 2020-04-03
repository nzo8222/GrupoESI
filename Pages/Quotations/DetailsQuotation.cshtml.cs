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
    public class DetailsQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DetailsQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Quotation Quotation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quotation = await _context.Quotation.FirstOrDefaultAsync(m => m.Id == id);

            if (Quotation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
