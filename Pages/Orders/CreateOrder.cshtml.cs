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

namespace GrupoESINuevo
{
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
            _OrderAndOrderDetailsVM.OrderModel.Id = new Guid();
            _OrderAndOrderDetailsVM.OrderDetailsModel.Id = new Guid();
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
          
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _context.ServiceModel
                                                                                    .Include(s =>s.ApplicationUser)
                                                                                    .Include(s=>s.serviceType)
                                                                                    .FirstOrDefault(s => s.ID == _OrderAndOrderDetailsVM.serviceIdVM);
            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderModel.EstadoDelPedido = SD.EstadoSinCotizar;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Cost = 0.0;
            _context.OrderDetails.Add(_OrderAndOrderDetailsVM.OrderDetailsModel);
            
            _context.Order.Add(_OrderAndOrderDetailsVM.OrderModel);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexOrder", new { serviceId = _OrderAndOrderDetailsVM.serviceIdVM });
        }
    }
}
