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
    public class DeleteServiceModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteServiceModel(GrupoESINuevo.Data.ApplicationDbContext context)
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
                                                     .Include(s => s.ApplicationUser)
                                                     .Include(s => s.serviceType)
                                                     .FirstOrDefaultAsync(m => m.ID == serviceId);

            if (ServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ServiceModel.ID == null)
            {
                return NotFound();
            }

            ServiceModel = _context.ServiceModel
                                                .FirstOrDefault(s => s.ID == ServiceModel.ID);

            var orderDetailsLocal = _context.OrderDetails
                                                         .Include(od => od.Order)
                                                         .Include(od => od.Service)
                                                         .Where(od => od.Service == ServiceModel).ToList();

            foreach (var item in orderDetailsLocal)
            {
                var quotationLocal = _context.Quotation
                                                        .Include(q => q.OrderDetailsModel)
                                                        .FirstOrDefault(q => q.OrderDetailsModel == item);
                _context.Quotation.Remove(quotationLocal);
                _context.OrderDetails.Remove(item);
            }
            if (ServiceModel != null)
            {
                _context.ServiceModel.Remove(ServiceModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
