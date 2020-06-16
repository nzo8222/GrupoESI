using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESINuevo.Models;
using GrupoESINuevo.Uitility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.ManageOrders
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class OrderIndexAdminModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;
        public List<Order> OrderList;
        public OrderIndexAdminModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            OrderList = _context.Order
                                      .Include(o => o.LstOrderDetails)
                                          .ThenInclude(od => od.Service)
                                          .ThenInclude(od => od.serviceType)
                                      .Where(o => o.EstadoDelPedido == SD.EstadoCotizado)
                                      .ToList();
            return Page();
        }
    }
}