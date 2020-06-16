using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GrupoESINuevo.Uitility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class ManageOrdersIndexModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public ManageOrdersIndexModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        

        [BindProperty]
        public ManageOrdersVM _manageOrdersVM { get; set; }

        public IActionResult OnGet(Guid orderId)
        {
            if(orderId == null)
            {
                return Page();
            }

            _manageOrdersVM = new ManageOrdersVM()
            {
                OrderModel = _context.Order.FirstOrDefault(o => o.Id == orderId),

                OrderDetailsList = _context.OrderDetails.Include(od => od.Order)
                                                       .Include(od => od.Service)
                                                           .ThenInclude(s => s.serviceType)
                                                           .Where(od => od.Order.Id == orderId).ToList(),

                ListQuotations = _context.Quotation.Include(q => q.OrderDetailsModel)
                                                       .ThenInclude(od => od.Order)
                                                     .Include(q => q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                     .Where(q => q.OrderDetailsModel.Order.Id == orderId).ToList(),

                ListServices = new List<ManageServiceQuotationVM>(),

                ServiceModelIdList = new List<Guid>(),

                stringIds = ""
            };

            ////lista de ID de servicios cotizados
            //List<Guid> listaIdServiciosCotizados = new List<Guid>();
            //foreach (var item in _manageOrdersVM.OrderDetailsList)
            //{
            //    listaIdServiciosCotizados.Add(item.Id);
            //}



            // lista de ID de servicios con el mismo tipo de servicio
            List<Guid> lstServiceDelmismoTipoDeLaOrden =    _context.ServiceModel
                                                                    .Include(c => c.serviceType)
                                                                    .Where(c => c.serviceType == _manageOrdersVM.OrderDetailsList[0].Service.serviceType)
                                                                    .Select(c => c.ID)
                                                                    .ToList();

            List<Guid> lstServiciosConCotizacion = new List<Guid>();

            foreach (var item in _manageOrdersVM.OrderDetailsList)
            {
                lstServiciosConCotizacion.Add(item.Service.ID);
            }

            lstServiceDelmismoTipoDeLaOrden = lstServiceDelmismoTipoDeLaOrden.FindAll(x => !lstServiciosConCotizacion.Contains(x));

            foreach (var item in lstServiceDelmismoTipoDeLaOrden)
            {
                var localVM = new ManageServiceQuotationVM()
                {
                    sendQuotation = false,
                    ServiceModel = _context.ServiceModel
                                                        .Include(s => s.ApplicationUser)
                                                        .FirstOrDefault(s => s.ID == item)
                };
                _manageOrdersVM.ListServices.Add(localVM);
            }
            
            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            var listaServicios = _manageOrdersVM.stringIds;
            //_context.Order.Add(Order);
            //await _context.SaveChangesAsync();//if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            return RedirectToPage("ManageOrdersIndex", new { orderId = _manageOrdersVM.OrderModel.Id });
        }
    }
}
