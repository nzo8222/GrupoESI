using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;

namespace GrupoESINuevo
{
    public class DeleteMaterialModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteMaterialModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeleteMaterialVM DeleteMaterialVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? materialId)
        {
            if (materialId == null)
            {
                return NotFound();
            }
            DeleteMaterialVM = new DeleteMaterialVM();
            DeleteMaterialVM.material = await _context.Material
                                                                .FirstOrDefaultAsync(m => m.Id == materialId);


            if (DeleteMaterialVM == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (DeleteMaterialVM.material.Id == null)
            {
                return NotFound();
            }
            DeleteMaterialVM.material =  _context.Material
                                                            .Include(m => m.Task)
                                                            .FirstOrDefault(m => m.Id == DeleteMaterialVM.material.Id);

            if (DeleteMaterialVM.material.Task != null)
            {
                var tarea = _context.Task
                                        .Include(t => t.QuotationModel)
                                            .ThenInclude(q => q.OrderDetailsModel)
                                        .Include(t => t.ListMaterial)
                                        .FirstOrDefault(t => t.Id == DeleteMaterialVM.material.Task.Id);
                tarea.QuotationModel.OrderDetailsModel.Cost = tarea.QuotationModel.OrderDetailsModel.Cost - DeleteMaterialVM.material.Price;
                tarea.Cost = tarea.Cost - DeleteMaterialVM.material.Price;
                _context.Material.Remove(DeleteMaterialVM.material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexMaterial", new { taskId = DeleteMaterialVM.material.Task.Id });
        }
    }
}
