using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;

namespace GrupoESINuevo
{
    public class EditMaterialModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditMaterialModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid materialId)
        {
            if (materialId == null)
            {
                return NotFound();
            }
           
            Material = await _context.Material
                                                .Include(m => m.Task)
                                                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (Material == null)
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
            var mat = _context.Material
                                        .Include(m => m.Task)
                                        .FirstOrDefault(m => m.Id == Material.Id);
            var task = _context.Task.FirstOrDefault(t => t.Id == mat.TaskModelId);
            task.Cost = task.Cost - (int)mat.Price + (int)Material.Price;
            mat.Name = Material.Name;
            mat.Price = Material.Price;
            mat.Description = Material.Description;
            
            //_context.Attach(Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(Material.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexMaterial", new { taskId = mat.Task.Id });
        }

        private bool MaterialExists(Guid id)
        {
            return _context.Material.Any(e => e.Id == id);
        }
    }
}
