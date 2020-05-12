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
        public DeleteMaterialVM Material { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Material = new DeleteMaterialVM();
            Material.material = await _context.Material.FirstOrDefaultAsync(m => m.Id == id);
            Material.taskId = Material.material.TaskModelId;

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Material.material = await _context.Material.FindAsync(id);

            if (Material != null)
            {
                _context.Material.Remove(Material.material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexMaterial", new { orderDetailsId = Material.taskId });
        }
    }
}
