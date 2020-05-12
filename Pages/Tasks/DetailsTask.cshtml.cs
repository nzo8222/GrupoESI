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
    public class DetailsModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DetailsModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TaskModel TaskModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskModel = await _context.Task.FirstOrDefaultAsync(m => m.Id == id);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
