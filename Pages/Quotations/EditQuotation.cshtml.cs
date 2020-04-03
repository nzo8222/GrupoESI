using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;

namespace GrupoESINuevo
{
    public class EditQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Quotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotationExists(Quotation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotation.Any(e => e.Id == id);
        }
    }
}
