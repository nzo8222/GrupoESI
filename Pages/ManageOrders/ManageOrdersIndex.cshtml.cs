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
            var orderDetailsList = _context.OrderDetails.Include(od => od.Order)
                                                        .Include(od => od.Service)
                                                            .ThenInclude(s => s.serviceType)
                                                            .Where(od => od.Order.Id == orderId).ToList();
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
                                                        .ThenInclude(t => t.ListMaterial).Where(q => q.OrderDetailsModel.Order.Id == orderId).ToList(),
                ListServices = _context.ServiceModel.Include(s => s.serviceType)
                                                    .Include(s => s.ApplicationUser)
                                                    .Where(s => s.serviceType.Id == orderDetailsList[0].Service.serviceType.Id).ToList()
            };

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

            //_context.Order.Add(Order);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
