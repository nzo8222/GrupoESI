using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Authorization;
using GrupoESINuevo.Uitility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteServiceTypeModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteServiceTypeModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (ServiceType.Id == null)
            {
                return NotFound();
            }
            //Categoria de servicio
            ServiceType = await _context.ServiceType
                                                    .FirstOrDefaultAsync(m => m.Id == ServiceType.Id);

            //Lista de servicios de esta categoria
            var lstServiciosServiceType = _context.ServiceModel
                                                                .Include(s => s.serviceType)
                                                                .Where(s => s.serviceType == ServiceType)
                                                                .ToList();
            //iterar la lista y obtener todos los orderDetails
            foreach (var item in lstServiciosServiceType)
            {

            }

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _context.ServiceType.FindAsync(id);

            if (ServiceType != null)
            {
                _context.ServiceType.Remove(ServiceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexServiceType");
        }
    }
}
