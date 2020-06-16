﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Authorization;
using GrupoESINuevo.Uitility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditOrderModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditOrderModel(GrupoESINuevo.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var orderLocal = _context.Order.FirstOrDefault(o => o.Id == Order.Id);
            orderLocal.Concepto = Order.Concepto;
            orderLocal.Direccion = Order.Direccion;
            orderLocal.OrderDate = Order.OrderDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderExists(Order.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("../ManageOrders/OrderIndexAdmin");
        }

        private bool OrderExists(Guid id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
