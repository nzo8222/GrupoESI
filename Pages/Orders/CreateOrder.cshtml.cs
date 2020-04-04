﻿using System;
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
        public string _service { get; set; }
        public async Task<IActionResult> OnGet(string serviceId = null)
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
            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _context.ServiceModel.FirstOrDefault(s => s.ID == Int32.Parse(serviceId));
            
            _OrderAndOrderDetailsVM.serviceIdVM = serviceId;

            //Order = new Order();


            //Order.ServiceId = );
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
            //_OrderAndOrderDetailsVM = new OrderAndOrderDetailsVM()
            //{
            //    OrderModel = new Order(),
            //};
            //_OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _context.ServiceModel
                                                                                    .Include(s =>s.ApplicationUser)
                                                                                    .Include(s=>s.serviceType)
                                                                                    .FirstOrDefault(s => s.ID == Int32.Parse(_OrderAndOrderDetailsVM.serviceIdVM));
            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderModel.EstadoDelPedido = SD.EstadoSinAceptar;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Cost = 0.0;
            _context.OrderDetails.Add(_OrderAndOrderDetailsVM.OrderDetailsModel);
            
            _context.Order.Add(_OrderAndOrderDetailsVM.OrderModel);
            //OrderDetailsModel = new OrderDetails();
            //Order.EstadoDelPedido = 
            //OrderDetailsModel.Service = _context.ServiceModel.FirstOrDefault(s => s.ID == Int32.Parse(_service));
            //OrderDetailsModel.Order = Order;
            //OrderDetailsModel.Cost = 0.0;
            //_context.OrderDetails.Add(OrderDetailsModel);
            //_context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexOrder", new { serviceId = _OrderAndOrderDetailsVM.serviceIdVM });
        }
    }
}
