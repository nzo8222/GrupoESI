using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;

namespace GrupoESINuevo
{
    public class DeleteQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderDetailsId)
        {
            if (orderDetailsId == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.OrderDetails.FirstOrDefaultAsync(m => m.Id == orderDetailsId);

            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (OrderDetails.Id == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.OrderDetails
                                                    .Include(o => o.Order)
                                                    .FirstOrDefaultAsync(od => od.Id == OrderDetails.Id);

            var quotationLocal = _context.Quotation.Include(q => q.OrderDetailsModel)
                                                   .Include(q => q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                   .FirstOrDefault(q => q.OrderDetailsModel.Id == OrderDetails.Id);

            if (OrderDetails != null && quotationLocal != null)
            {
                var orderDetailFromSameOrder = _context.OrderDetails
                                                                .Include(od => od.Order)
                                                                .Where(od => od.Order == OrderDetails.Order).ToList();
                if(orderDetailFromSameOrder.Count == 1 )
                {
                    _context.Order.Remove(orderDetailFromSameOrder[0].Order);
                }
                _context.OrderDetails.Remove(OrderDetails);
                _context.Quotation.Remove(quotationLocal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
