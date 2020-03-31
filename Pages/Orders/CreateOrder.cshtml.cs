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
        public Order Order { get; set; }
        public async Task<IActionResult> OnGet(string serviceId = null)
        {
           if(serviceId == null)
            {
                return Page();
            }
            Order = new Order();
            Order.ServiceId = Int32.Parse(serviceId);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexOrder", new { serviceId = Order.ServiceId });
        }
    }
}
