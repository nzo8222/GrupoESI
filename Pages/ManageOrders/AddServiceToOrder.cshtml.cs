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

        public async Task OnGetAsync(Guid orderDetailsId)
        {
            //se inicializa el modelo y se le asigna el atributo orderDetailsID
            _AddServiceVM = new AddServiceVM(orderDetailsId);
            //se buscan todas las detalles de orden que tengan el mismo id de la orden que el recibido en el parametro y sean del mismo usuario
            var orderDetailsLocal = _context.OrderDetails
                                                                  .Include(od => od.Order)
                                                                  .Include(od => od.Service)
                                                                       .ThenInclude(s => s.ApplicationUser)
                                                                  .FirstOrDefault(od => od.Id == orderDetailsId);
            _AddServiceVM.OrderDetailsList = _context.OrderDetails
                                                                  .Include(od => od.Order)
                                                                  .Include(od => od.Service)
                                                                       .ThenInclude(s => s.ApplicationUser)
                                                                  .Where(orderDtls => orderDtls.Order.Id == orderDetailsLocal.Order.Id && orderDtls.Service.ApplicationUser == orderDetailsLocal.Service.ApplicationUser)
                                                                  .ToList();
            //si hay mas de 0 servicios en la cuenta se inicializa el atributo orderId con el id de la orden del primer
            //registro de la lista de orderDetails
            if (_AddServiceVM.OrderDetailsList.Count > 0)
            {
                _AddServiceVM.OrderId = _AddServiceVM.OrderDetailsList[0].Order.Id;
            }
            
            //_AddServiceVM.lstServicios = _context.ServiceModel
            //                                                 .Include(s => s.ApplicationUser)
            //                                                 .Where(s => s.ApplicationUser.Id == _AddServiceVM.OrderDetailsList[0].Service.ApplicationUser.Id).ToList();
           
            // lista de ID de servicios del mismo usuario
            List<Guid> lstServiceDelmismoUsuario = _context.ServiceModel
                                                                    .Include(c => c.ApplicationUser)
                                                                    .Where(c => c.ApplicationUser == _AddServiceVM.OrderDetailsList[0].Service.ApplicationUser)
                                                                    .Select(c => c.ID)
                                                                    .ToList();
            //lista de servicios con cotizacion
            List<Guid> lstServiciosConCotizacion = new List<Guid>();

            //por cada orderDetails se agrega el id del servicio a la lista de servicios con cotizacion
            foreach (var item in _AddServiceVM.OrderDetailsList)
            {
                lstServiciosConCotizacion.Add(item.Service.ID);
            }
            //de la lista de servicios del mismo usuario se excluyen aquellos registros que ya tengan un OrderDetails 
            lstServiceDelmismoUsuario = lstServiceDelmismoUsuario.FindAll(x => !lstServiciosConCotizacion.Contains(x));

            //por cada servicio del mismo usuario que sobre despues de excluir los que ya tienen un orderDetails 
            //se agrega un modelo de servicio a una lista del viewModel
            foreach(var item in lstServiceDelmismoUsuario)
            {
                var serviceModel = _context.ServiceModel
                                                        .Include(s => s.ApplicationUser)
                                                        .FirstOrDefault(s => s.ID == item);
                _AddServiceVM.lstServicios.Add(serviceModel);
            }
        }

    }
}
