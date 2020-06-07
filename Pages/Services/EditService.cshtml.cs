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
    public class EditeServiceModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditeServiceModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceModel = await _context.ServiceModel
                                                      .Include(s => s.serviceType)
                                                      .Include(s => s.ApplicationUser)
                                                      .FirstOrDefaultAsync(m => m.ID == serviceId);

            if (ServiceModel == null)
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
            var service = _context.ServiceModel.FirstOrDefault(s => s.ID == ServiceModel.ID);
            service.Name = ServiceModel.Name;
            service.Description = ServiceModel.Description;
            _context.ServiceModel.Update(service);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ServiceModelExists(ServiceModel.ID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        private bool ServiceModelExists(Guid id)
        {
            return _context.ServiceModel.Any(e => e.ID == id);
        }
    }
}
