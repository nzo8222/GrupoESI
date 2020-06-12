using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;

namespace GrupoESINuevo
{
    public class DeleteModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DeleteModel(GrupoESINuevo.Data.ApplicationDbContext context)
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

            TaskModel = await _context.Task
                                           .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetailsModel)
                                           .FirstOrDefaultAsync(m => m.Id == taskId);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }

            TaskModel = await _context.Task.Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetailsModel)
                                                .FirstOrDefaultAsync(t => t.Id == taskId);

            if (TaskModel != null)
            {
                _context.Task.Remove(TaskModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = TaskModel.QuotationModel.OrderDetailsModel.Id });
        }
    }
}
