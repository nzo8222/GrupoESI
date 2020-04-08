using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo
{
    public class CreateMaterialModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public CreateMaterialModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public TaskMaterialVM _TaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid taskId )
        {
            if(taskId == null)
            {
                return Page();
            }
            _TaskMaterialVM = new TaskMaterialVM()
            {
                MaterialModel = new Material(),
                TareaModel = _context.Task.FirstOrDefault(t => t.Id == taskId),
                taskId = taskId
            };
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
            
            _TaskMaterialVM.TareaModel = _context.Task
                                                        .Include(t => t.ListMaterial)
                                                        .Include(t => t.QuotationModel)
                                                        .ThenInclude(q => q.OrderDetailsModel)
                                                        .FirstOrDefault(t => t.Id == _TaskMaterialVM.taskId);
            _TaskMaterialVM.TareaModel.ListMaterial.Add(_TaskMaterialVM.MaterialModel);
            _context.Task.Update(_TaskMaterialVM.TareaModel);
          
            //_context.Material.Add();
            await _context.SaveChangesAsync();

            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = _TaskMaterialVM.TareaModel.QuotationModel.OrderDetailsModel.Id });
        }
    }
}
