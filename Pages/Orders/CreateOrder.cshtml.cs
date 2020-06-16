using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Uitility;
using GrupoESINuevo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public CreateOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
           
        }

       
        [BindProperty]
        public OrderAndOrderDetailsVM _OrderAndOrderDetailsVM { get; set; }
        public async Task<IActionResult> OnGet(Guid serviceId)
        {
           if(serviceId == null)
            {
                return Page();
            }
            _OrderAndOrderDetailsVM = new OrderAndOrderDetailsVM()
            {
                OrderModel = new Order(),
                OrderDetailsModel = new OrderDetails()
            };
            //_OrderAndOrderDetailsVM.OrderModel.Id = new Guid();
            //_OrderAndOrderDetailsVM.OrderDetailsModel.Id = new Guid();
            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _context.ServiceModel.FirstOrDefault(s => s.ID == serviceId);
            
            _OrderAndOrderDetailsVM.serviceIdVM = serviceId;

            //Order = new Order();


            //Order.ServiceId = );
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            //se le asigna el servicio a la entidad OrderDetails
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _context.ServiceModel
                                                                                    .Include(s =>s.ApplicationUser)
                                                                                    .Include(s=>s.serviceType)
                                                                                    .FirstOrDefault(s => s.ID == _OrderAndOrderDetailsVM.serviceIdVM);
            //se le asigna el estado sin cotizar a la orden
            _OrderAndOrderDetailsVM.OrderModel.EstadoDelPedido = SD.EstadoSinCotizar;
            //se asigna la orden al order details

            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            //se asigna un estado al orderDetails
            _OrderAndOrderDetailsVM.OrderModel.EstadoDelPedido = SD.EstadoSinCotizar;
            //se asigna un costo, no es necesario inicializarse en 0 porque ya lo hace el compilador automaticamente.
            _OrderAndOrderDetailsVM.OrderDetailsModel.Cost = 0.0;
            //declarar una entidad Quotation
            var quotationLocal = new Quotation();
            //inicializo la lista de tareas porque si no se enoja el compilador
            quotationLocal.Tasks = new List<TaskModel>();
            //se asigna el orderDetails a la cotizacion que acabamos de crear
            quotationLocal.OrderDetailsModel = _OrderAndOrderDetailsVM.OrderDetailsModel;
            //se agregan las entidades creadas al contexto
            _context.Quotation.Add(quotationLocal);
            _context.OrderDetails.Add(_OrderAndOrderDetailsVM.OrderDetailsModel);
            
            _context.Order.Add(_OrderAndOrderDetailsVM.OrderModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }

            return RedirectToPage("./IndexOrder", new { serviceId = _OrderAndOrderDetailsVM.serviceIdVM });
        }
    }
}
