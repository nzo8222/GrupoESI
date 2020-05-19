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
    public class EditModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }
            TaskModel = await _context.Task.FirstOrDefaultAsync(m => m.Id == taskId);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var task = _context.Task
                                   .Include(t => t.QuotationModel)
                                       .ThenInclude(q => q.OrderDetailsModel)
                                   .FirstOrDefault(t => t.Id == TaskModel.Id);
            task.Name = TaskModel.Name;
            task.Description = TaskModel.Description;
            task.Duration = TaskModel.Duration;
            task.Cost = task.Cost - task.CostHandLabor + TaskModel.CostHandLabor;
            task.CostHandLabor = TaskModel.CostHandLabor;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(TaskModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = task.QuotationModel.OrderDetailsModel.Id });
        }

        private bool TaskModelExists(Guid id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
