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

        public async Task<IActionResult> OnGetAsync(Guid serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return NotFound();
            }
            //Categoria de servicio
            ServiceType = await _context.ServiceType
                                                    .FirstOrDefaultAsync(m => m.Id == serviceTypeId);

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ServiceType.Id == null)
            {
                return NotFound();
            }
            //Modelo
            ServiceType = await _context.ServiceType.FindAsync(ServiceType.Id);
            //si el modelo es diferente a null
            if (ServiceType != null)
            {
                //obtener todos los servicios de con este serviceType
                var lstService = _context.ServiceModel
                                                    .Include(s => s.serviceType)
                                                    .Where(s => s.serviceType == ServiceType)
                                                    .ToList();
                //iterar cada servicio y obtener todos los order Details Quotation y materiales
                foreach (var item in lstService)
                {
                    //obtener todos los order Details
                    var orderDetailsLocal = _context.OrderDetails
                                                         .Include(od => od.Order)
                                                         .Include(od => od.Service)
                                                         .Where(od => od.Service == item).ToList();

                    foreach (var item2 in orderDetailsLocal)
                    {
                        //Obtener todas las cotizaciones tareas y materiales
                        var quotationLocal = _context.Quotation
                                                                .Include(q => q.OrderDetailsModel)
                                                                .Include(q => q.Tasks)
                                                                    .ThenInclude(t => t.ListMaterial)
                                                                .FirstOrDefault(q => q.OrderDetailsModel == item2);
                        if(quotationLocal != null)
                        {
                            _context.Quotation.Remove(quotationLocal);
                        }
                        
                        _context.OrderDetails.Remove(item2);
                    }
                   
                    //borrar entidades
                    //cargar una variable con el servicio para borrarla
                    var serviceLocal = _context.ServiceModel.FirstOrDefault(s => s == item);
                    _context.ServiceModel.Remove(serviceLocal);
                    await _context.SaveChangesAsync();
                }
                _context.ServiceType.Remove(ServiceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexServiceType");
        }
    }
}
