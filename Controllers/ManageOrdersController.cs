using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;
using GrupoESINuevo.Uitility;
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
            List<string> result = _pmovm.idService.Split(',').ToList();
            
            foreach (var item in result)
            {
                var _OrderDetailsNueva = new OrderDetails();
                var quotationLocal = new Quotation();

                quotationLocal.Tasks = new List<TaskModel>();
                //_OrderDetailsNueva.Id = Guid.NewGuid();
                _OrderDetailsNueva.Order = _context.Order.FirstOrDefault(o => o.Id == _pmovm.orderId);
                _OrderDetailsNueva.Service = _context.ServiceModel.FirstOrDefault(s => s.ID.ToString() == item);

                var quotation = _context.Quotation
                                                 .AsNoTracking()
                                                 .Include(q => q.OrderDetailsModel)
                                                    .ThenInclude(q => q.Order)
                                                 .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.ListMaterial)
                                                 .FirstOrDefault(q => q.OrderDetailsModel.Order.Id == _pmovm.orderId);
                
                var pics = _context.Quotation
                                                .AsNoTracking()
                                                .Include(q => q.OrderDetailsModel)
                                                    .ThenInclude(q => q.Order)
                                                 .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.Pictures)
                                                 .FirstOrDefault(q => q.OrderDetailsModel.Order.Id == _pmovm.orderId);
                
                var piclist = new List<Picture>();

                for (int i = 0; i < quotation.Tasks.Count; i++)
                {
                    var _taskLocal = new TaskModel();
                    
                    for (int f = 0; f < quotation.Tasks[i].ListMaterial.Count; f++)
                    {
                        if(_taskLocal.ListMaterial == null)
                        {
                            _taskLocal.ListMaterial = new List<Material>();
                        }
                        var mat = new Material();
                        mat.Description = quotation.Tasks[i].ListMaterial[f].Description;
                        mat.Name = quotation.Tasks[i].ListMaterial[f].Name;
                        mat.Price = 0;
                        _taskLocal.ListMaterial.Add(mat);
                    }

                    if(_taskLocal.Pictures == null)
                    {
                        _taskLocal.Pictures = new List<Picture>();
                    }

                        for (int e = 0; e < pics.Tasks[i].Pictures.Count; e++)
                    {
                        var picLocal = new Picture();
                        picLocal.PictureBytes = pics.Tasks[i].Pictures[e].PictureBytes;
                        _taskLocal.Pictures.Add(picLocal);
                    }
                    _taskLocal.Name = quotation.Tasks[i].Name;
                    _taskLocal.Duration = quotation.Tasks[i].Duration;
                    _taskLocal.Description = quotation.Tasks[i].Description;
                    quotationLocal.Tasks.Add(_taskLocal);
                }

                quotationLocal.Description = quotation.Description;
                quotationLocal.Status = 0;
                quotationLocal.OrderDetailsModel = _OrderDetailsNueva;
               
                _context.OrderDetails.Add(_OrderDetailsNueva);
                _context.Quotation.Add(quotationLocal);
            }
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("PostServiceToOrder")]
        public IActionResult PostServiceToOrder([FromBody] PostServiceToOrderVM serviceToOrderVM)
        {
            List<string> result = serviceToOrderVM.serviceId.Split(',').ToList();
            var localOrderDetails = _context.OrderDetails.Include(o => o.Order).Where(orderDetails => orderDetails.Order.Id == serviceToOrderVM.orderDetailsId).ToList();
            foreach (var item in result)
            {
                var od = new OrderDetails();
                var orderLocal = _context.OrderDetails.Include(od => od.Order).FirstOrDefault(od => od.Id == serviceToOrderVM.orderDetailsId);
                od.Order = orderLocal.Order;
                od.Service = _context.ServiceModel.FirstOrDefault(s => s.ID.ToString() == item);
                od.Cost = 0;
                //var quotation = _context.Quotation
                //                                 .Include(q => q.OrderDetailsModel)
                //                                    .ThenInclude(q => q.Order)
                //                                 .Include(q => q.Tasks)
                //                                    .ThenInclude(t => t.ListMaterial)
                //                                 .FirstOrDefault(q => q.OrderDetailsModel.Order.Id == serviceToOrderVM.orderId);
                //foreach (var tasks in quotation.Tasks)
                //{
                //    tasks.Cost = 0;
                //    foreach (var material in tasks.ListMaterial)
                //    {
                //        material.Price = 0;
                //    }
                //}
                //quotation.OrderDetailsModel = od;
                _context.OrderDetails.Add(od);
                //_context.Quotation.Add(quotation);
            }
            _context.SaveChanges();
            //var a = _pmovm;
            ////return LocalRedirect("/Identity/Account/Login?id=")
            return Ok();
            //return RedirectToAction();
        }
        [HttpPost]
        [Route("PostDeletePictures")]
        public IActionResult PostDeletePictures([FromBody] DeletePictureVM deletePictureVM)
        {
            List<string> result = deletePictureVM.deletePicturesId.Split(',').ToList();
            var task = _context.Task
                                    .Include(t => t.Pictures)
                                    .FirstOrDefault(q => q.Id == deletePictureVM.taskId);
            foreach (var item in result)
            {
                var pic = task.Pictures.Find(p => p.PictureId.ToString() == item);
                task.Pictures.Remove(pic);
            }
            try
            {
                _context.SaveChanges();
            }catch(Exception ex)
            {

            }
            
            return Ok();
        }

        [HttpPost]
        [Route("PostAssignQuotation")]
        public IActionResult PostAssignQuotation([FromBody] PostAssignQuotationVM _PostAssignQuotationVM)
        {
            var quotation = _context.Quotation.FirstOrDefault(q => q.Id == _PostAssignQuotationVM.idQuotation);
            //quotation.Status = 1;
            var orderDetails = _context.OrderDetails.Include(od => od.Order).FirstOrDefault(od => od.Id == _PostAssignQuotationVM.idOrderDetails);
            var orders = _context.OrderDetails
                                              .Include(od => od.Order)
                                              .Where(od => od.Order.Id == orderDetails.Order.Id).ToList();
            foreach (var item in orders)
            {
                if(item != orderDetails)
                {
                    item.Status = 1;
                }
                else
                {
                    item.Status = 2;
                    item.Order.EstadoDelPedido = SD.EstadoAsignado;
                }
            }
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }
        }
}