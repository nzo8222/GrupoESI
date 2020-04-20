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

namespace GrupoESINuevo
{
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
            //var orderDetailsList = _context.OrderDetails.Include(od => od.Order)
            //                                            .Include(od => od.Service)
            //                                                .ThenInclude(s => s.serviceType)
            //                                                .Where(od => od.Order.Id == orderId).ToList();

            //lista de ID de servicios cotizados
            List<Guid> listaIdServiciosCotizados = new List<Guid>();
            foreach (var item in _manageOrdersVM.OrderDetailsList)
            {
                listaIdServiciosCotizados.Add(item.Id);
            }



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
            //var localVM = new ManageServiceQuotationVM()
            //{
            //    sendQuotation = false,
            //    //ServiceModel = servicio
            //};
            

            //IQueryable<String> lstServiciosCotizados = _context.OrderDetails
            //                                                                .Include(od => od.Order)
            //                                                                .Include(od => od.Service)
            //                                                                .Where(od => od.Order.Id == orderId)
            //                                                                .Select(od => od.Service.Name);
           
            //var query = from b in _context.Set<Service>()
            //            join p in _context.Set<ServiceType>()
            //                on b.serviceType.Id equals p.Id into grouping
            //            select new { b, ServiceType = grouping.Where(p => p.Id.ToString().Contains(lstServiceDelmismoTipoDeLaOrden.ToString())).ToList() };
       
            ////lista de todos los servicios que coinciden con tipo de servicio de la orden
            //var listaServiciosPrimera = _context.ServiceModel.Include(s => s.serviceType)
            //                                                 .Include(s => s.ApplicationUser)
            //                                                 .Where(s => s.serviceType.Id == _manageOrdersVM.OrderDetailsList[0].Service.serviceType.Id).ToList();


            //var listaOriginal = 
            //List<object> idslisttoexclude = [1, 3, 6, 8, 9]

            //Listaoriginal = listaoriginal.findall(x => !Idslisttoexclude.contains(x));

            //se agregan a la lista de servicios aquellos servicios que aun no tienen un detalle de orden con el id de la orden 
            //foreach (var servicio in listaServiciosPrimera)
            //{
            //    foreach (var idServicio in lstServiceDelmismoTipoDeLaOrden)
            //    {
            //        if(idServicio != servicio.ID && lstServiceDelmismoTipoDeLaOrden.Contains(servicio.ID))
            //        {
            //            var localVM = new ManageServiceQuotationVM()
            //            {
            //                sendQuotation = false,
            //                ServiceModel = servicio
            //            };
            //            _manageOrdersVM.ListServices.Add(localVM);
            //        }
            //    }
               
            //}
            //if (!lstService.Contains(servicio.ID))
            //{

            //}
            //var listServicesLocal = new List<Service>();
            //foreach (var item in listaServiciosPrimera)
            //{
            //    var localVM = new ManageServiceQuotationVM()
            //    {
            //        sendQuotation = false,
            //        ServiceModel = item
            //    };
            //    _manageOrdersVM.ListServices.Add(localVM);
            //}



                                                                         //.Where(s => !listaIdServiciosCotizados.Contains(s.ID))
            //from s in _context.ServiceModel
            //                                    where !(lstService.Contains(s.ID))
            //                                    where s.serviceType == orderDetailsList[0].Service.serviceType
            //                                    select s;





            //customers.Include(c => c.Orders.Where(o => o.Name != "Foo").OrderByDescending(o => o.Id).Take(3))
            //_context.ServiceModel.Include(s => s.serviceType)
            //                                   .Include(s => s.ApplicationUser)
            //                                   .Where(s => s.serviceType.Id == orderDetailsList[0].Service.serviceType.Id).ToList();



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
