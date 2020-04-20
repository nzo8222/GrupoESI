using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
            public ManageOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("PostManageOrders")]
        public IActionResult PostNewOrders([FromBody] PostManageOrdersVM _pmovm)
        {
            List<string> result = _pmovm.name.Split(',').ToList();
            
            foreach (var item in result)
            {
                var od = new OrderDetails();
                od.Id = Guid.NewGuid();
                od.Order = _context.Order.FirstOrDefault(o => o.Id == _pmovm.orderId);
                od.Service = _context.ServiceModel.FirstOrDefault(s => s.ID.ToString() == item);
                od.Cost = 0;
                var quotation = _context.Quotation
                                                 .Include(q => q.OrderDetailsModel)
                                                    .ThenInclude(q => q.Order)
                                                 .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.ListMaterial)
                                                 .FirstOrDefault(q => q.OrderDetailsModel.Order.Id == _pmovm.orderId);
                foreach (var tasks in quotation.Tasks)
                {
                    tasks.Cost = 0;
                    foreach (var material in tasks.ListMaterial)
                    {
                        material.Price = 0;
                    }
                }
                quotation.Id = Guid.NewGuid();
                quotation.OrderDetailsModel = od;
                _context.OrderDetails.Add(od);
                _context.Quotation.Add(quotation);
            }
            _context.SaveChanges();
            var a = _pmovm;
            //return LocalRedirect("/Identity/Account/Login?id=")
            return RedirectToAction("ManageOrdersIndex", new { orderId =_pmovm.orderId  });
        }
    }
}