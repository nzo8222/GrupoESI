using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo
{
    public class DeleteUserModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteUserModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ApplicationUser _ApplicationUser { get; set; }
        public async Task<IActionResult> OnGet(string userId)
        {
            if (userId == "")
            {
                return NotFound();
            }
            _ApplicationUser = _context.ApplicationUser.FirstOrDefault(a => a.Id == userId);
            if (_ApplicationUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_ApplicationUser.Id == "")
            {
                return NotFound();
            }

            _ApplicationUser =  _context.ApplicationUser
                                        .FirstOrDefault(o => o.Id == _ApplicationUser.Id);


            if (_ApplicationUser != null)
            {
                //lista de servicios del mismo usuario
                var serviciosListLocal = _context.ServiceModel
                                                              .Include(s => s.ApplicationUser)
                                                              .Where(s => s.ApplicationUser.Id == _ApplicationUser.Id)
                                                              .ToList();
                //iterar la lista de servicios
                foreach (var item in serviciosListLocal)
                {
                    //buscar todas las ordenes de cada servicio
                    var orderDetailsLocal = _context.OrderDetails
                                                            .Include(od => od.Order)
                                                            .Include(od => od.Service)
                                                                .ThenInclude(s => s.ApplicationUser)
                                                            .Where(od => od.Service.ID == item.ID).ToList();
                    //por cada orderDetails buscar las quotation tareas y materiales
                    foreach (var item2 in orderDetailsLocal)
                    {
                        
                        var quotationLocal = _context.Quotation
                                                                .Include(q => q.OrderDetailsModel)
                                                                .Include(q => q.Tasks)
                                                                    .ThenInclude(t => t.ListMaterial)
                                                                .FirstOrDefault(q => q.OrderDetailsModel == item2);
                        //remover el order details actual
                        _context.OrderDetails.Remove(item2);
                        if (quotationLocal != null)
                        {
                            //remover el quotation actual
                            _context.Quotation.Remove(quotationLocal);
                        }
                        //buscar si la orden tiene otros orderDetails 
                        var _order = _context.Order.FirstOrDefault(o => o.Id == item2.Order.Id);
                        var orderDetailsConEstaOrden = _context.OrderDetails
                                                                            .Include(o => o.Order)
                                                                            .Where(o => o.Order == _order).ToList();
                        //si no hay ninguna otra cotizacion en esta orden se borra
                        if(orderDetailsConEstaOrden.Count > 0)
                        {

                        }
                        else
                        {
                            //remover la orden
                            _context.Order.Remove(_order);
                        }
                    }
                    //borrar el servicio
                    var servicioLocal = _context.ServiceModel.FirstOrDefault(s => s == item);
                    _context.ServiceModel.Remove(servicioLocal);
                }

                _context.ApplicationUser.Remove(_ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexUser");
        }
    }
}