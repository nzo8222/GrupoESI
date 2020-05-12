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
            var orderDetails = _context.OrderDetails
                                                    .Include(od => od.Service)
                                                        .ThenInclude(s => s.ApplicationUser)
                                                    .Include(od => od.Order)
                                                    .Where(od => od.Order.Id == orderId).ToList();

            _AddServiceVM.lstServicios = _context.ServiceModel
                                                             .Include(s => s.ApplicationUser)
                                                             .Where(s => s.ApplicationUser.Id == orderDetails[0].Service.ApplicationUser.Id).ToList();
            

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var orderDetails = _context.OrderDetails.FirstOrDefault(od => od.Id == _AddServiceVM.orderId);
            return RedirectToPage("", new { });
        }
    }
}
