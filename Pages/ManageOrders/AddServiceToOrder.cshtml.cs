using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;

namespace GrupoESINuevo
{
    public class AddServiceToOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public AddServiceToOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddServiceVM _AddServiceVM { get;set; }

        public async Task OnGetAsync(Guid orderId)
        {
            _AddServiceVM = new AddServiceVM(orderId);

            _AddServiceVM.OrderDetailsList = _context.OrderDetails
                                                                  .Include(od => od.Order)
                                                                  .Include(od => od.Service)
                                                                       .ThenInclude(s => s.ApplicationUser)
                                                                  .Where(od => od.Order.Id == orderId).ToList();

            //_AddServiceVM.lstServicios = _context.ServiceModel
            //                                                 .Include(s => s.ApplicationUser)
            //                                                 .Where(s => s.ApplicationUser.Id == _AddServiceVM.OrderDetailsList[0].Service.ApplicationUser.Id).ToList();
            // lista de ID de servicios del mismo usuario
            List<Guid> lstServiceDelmismoUsuario = _context.ServiceModel
                                                                    .Include(c => c.ApplicationUser)
                                                                    .Where(c => c.ApplicationUser == _AddServiceVM.OrderDetailsList[0].Service.ApplicationUser)
                                                                    .Select(c => c.ID)
                                                                    .ToList();

            List<Guid> lstServiciosConCotizacion = new List<Guid>();
            foreach (var item in _AddServiceVM.OrderDetailsList)
            {
                lstServiciosConCotizacion.Add(item.Service.ID);
            }
            lstServiceDelmismoUsuario = lstServiceDelmismoUsuario.FindAll(x => !lstServiciosConCotizacion.Contains(x));

            foreach(var item in lstServiceDelmismoUsuario)
            {
                var serviceModel = _context.ServiceModel
                                                        .Include(s => s.ApplicationUser)
                                                        .FirstOrDefault(s => s.ID == item);
                _AddServiceVM.lstServicios.Add(serviceModel);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var orderDetails = _context.OrderDetails.FirstOrDefault(od => od.Id == _AddServiceVM.orderId);
            return RedirectToPage("", new { });
        }
    }
}
