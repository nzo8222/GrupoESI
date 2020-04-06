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
        public IActionResult OnGet(string orderDetailsId = null)
        {
            if(orderDetailsId == null)
            {
                return Page();
            }
            
            var quotationlocal = _context.Quotation
                                                    .Include(q =>q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                        .FirstOrDefault(q => q.OrderDetailsModel.Id == Int32.Parse(orderDetailsId));
            
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
                }
                  
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
            var quotation = new Quotation();
            quotation.OrderDetailsModel = _context.OrderDetails.FirstOrDefault(od => od.Id == Int32.Parse(_QuotationTaskMaterialVM.orderDetailsId));
            if(_QuotationTaskMaterialVM.QuotationModel.Tasks == null)
            {
                quotation.Tasks = new List<TaskModel>();
            }
            else
            {
                quotation.Tasks = _QuotationTaskMaterialVM.QuotationModel.Tasks.ToList();
            }
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
