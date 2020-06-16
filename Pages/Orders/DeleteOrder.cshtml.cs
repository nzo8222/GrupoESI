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
    public class DeleteOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                                        .FirstOrDefaultAsync(m => m.Id == orderId);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Order.Id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                                        .FirstOrDefaultAsync(o => o.Id == Order.Id);

            
            if (Order != null)
            {
                var orderDetailsLocal = _context.OrderDetails.Include(od => od.Order).Where(od => od.Order.Id == Order.Id).ToList();

                foreach (var item in orderDetailsLocal)
                {
                    var quotationLocal = _context.Quotation
                                                            .Include(q => q.OrderDetailsModel)
                                                            .Include(q => q.Tasks)
                                                                .ThenInclude(t => t.ListMaterial)
                                                            .FirstOrDefault(q => q.OrderDetailsModel == item);
                    
                    _context.OrderDetails.Remove(item);
                    if(quotationLocal != null)
                    {
                        _context.Quotation.Remove(quotationLocal);
                    }
                    
                }
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../ManageOrders/OrderIndexAdmin");
        }
    }
}
