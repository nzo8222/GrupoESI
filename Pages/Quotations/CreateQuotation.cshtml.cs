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
using GrupoESINuevo.Models.ViewModels;
using GrupoESINuevo.Uitility;

namespace GrupoESINuevo
{
    public class CreateQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public CreateQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public QuotationTaskMaterialVM _QuotationTaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {
            if(orderDetailsId == null)
            {
                return Page();
            }
            
            var quotationlocal = _context.Quotation
                                                    .Include(q =>q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                        .FirstOrDefault(q => q.OrderDetailsModel.Id == orderDetailsId);
            
            if (quotationlocal == null)
            {
                _QuotationTaskMaterialVM = new QuotationTaskMaterialVM()
                {
                    QuotationModel = new Quotation(),
                    MaterialModel = new Material(),
                    taskModel = new TaskModel(),
                    lstMaterial = new List<Material>(),
                    lstTaskModel = new List<TaskModel>(),
                    orderDetailsId = orderDetailsId
                };
                _QuotationTaskMaterialVM.QuotationModel.Id = new Guid();
                _QuotationTaskMaterialVM.MaterialModel.Id = new Guid();
                _QuotationTaskMaterialVM.taskModel.Id = new Guid();
            }
            else
            {
                var listaTareaslocal = quotationlocal.Tasks;
                if (listaTareaslocal == null)
                {
                    _QuotationTaskMaterialVM = new QuotationTaskMaterialVM()
                    {
                        QuotationModel = quotationlocal,
                        MaterialModel = new Material(),
                        taskModel = new TaskModel(),
                        lstMaterial = new List<Material>(),
                        lstTaskModel = new List<TaskModel>(),
                        orderDetailsId = orderDetailsId
                    };
                    _QuotationTaskMaterialVM.MaterialModel.Id = new Guid();
                    _QuotationTaskMaterialVM.taskModel.Id = new Guid();
                }
                else
                {
                    var listaMaterialesLocal = new List<Material>();
                    
                    foreach (var item in listaTareaslocal)
                    {
                        var listaMaterialesDentroDelForEach = item.ListMaterial.ToList();
                        foreach (var objetoMaterial in listaMaterialesDentroDelForEach)
                        {
                            listaMaterialesLocal.Add(objetoMaterial);
                        }
                    };
                    if(listaMaterialesLocal.Count() > 0)
                    {
                        _QuotationTaskMaterialVM = new QuotationTaskMaterialVM()
                        {
                            QuotationModel = quotationlocal,
                            MaterialModel = new Material(),
                            taskModel = new TaskModel(),
                            lstMaterial = listaMaterialesLocal,
                            lstTaskModel = listaTareaslocal,
                            orderDetailsId = orderDetailsId
                        };
                        _QuotationTaskMaterialVM.MaterialModel.Id = new Guid();
                        _QuotationTaskMaterialVM.taskModel.Id = new Guid();
                    }
                    else
                    {
                        _QuotationTaskMaterialVM = new QuotationTaskMaterialVM()
                        {
                            QuotationModel = quotationlocal,
                            MaterialModel = new Material(),
                            taskModel = new TaskModel(),
                            lstMaterial = new List<Material>(),
                            lstTaskModel = listaTareaslocal,
                            orderDetailsId = orderDetailsId
                        };
                        _QuotationTaskMaterialVM.MaterialModel.Id = new Guid();
                        _QuotationTaskMaterialVM.taskModel.Id = new Guid();
                    }
                   
                }
                  
            }

            

            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.orderDetailsId });
            //}
            var quotation = _context.Quotation
                                                .Include(q => q.Tasks)
                                                .Include(q => q.OrderDetailsModel)
                                                .ThenInclude(od => od.Order)
                                                .FirstOrDefault(q => q.Id == _QuotationTaskMaterialVM.QuotationModel.Id);

            if(quotation.Tasks.Count == 0)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.orderDetailsId });
            }
            quotation.Description = _QuotationTaskMaterialVM.QuotationModel.Description;

            _context.Quotation.Update(quotation);
            var order = _context.Order.FirstOrDefault(o => o.Id == quotation.OrderDetailsModel.Order.Id);
            order.EstadoDelPedido = SD.EstadoCotizado;
             _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexQuotation");
        }
        public async Task<IActionResult> OnPostAddMaterial()
        {
           
            _context.Material.Add(_QuotationTaskMaterialVM.MaterialModel);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteMaterial()
        {
            _QuotationTaskMaterialVM.lstMaterial.Remove(_QuotationTaskMaterialVM.MaterialModel);
            return Page();
        }
       
        public async Task<IActionResult> OnPostAddTaskModel()
        {
            var quotation = _context.Quotation.Include(q => q.OrderDetailsModel).FirstOrDefault(q => q.OrderDetailsModel.Id == _QuotationTaskMaterialVM.orderDetailsId); 

            if(quotation == null)
            {
                quotation = new Quotation();
            }
            quotation.OrderDetailsModel = _context.OrderDetails.FirstOrDefault(od => od.Id == _QuotationTaskMaterialVM.orderDetailsId);
            quotation.Tasks = new List<TaskModel>();
            _QuotationTaskMaterialVM.taskModel.QuotationModel = quotation;
            quotation.Tasks.Add(_QuotationTaskMaterialVM.taskModel);
            _context.Quotation.Add(quotation);
            await _context.SaveChangesAsync();

            return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.orderDetailsId });
        }
        public async Task<IActionResult> OnPostDeleteTaskModel()
        {
            _QuotationTaskMaterialVM.lstTaskModel.Remove(_QuotationTaskMaterialVM.taskModel);
            return Page();
        }
    }
}
