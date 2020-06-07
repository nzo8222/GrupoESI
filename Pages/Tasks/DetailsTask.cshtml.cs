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
using System.IO;

namespace GrupoESINuevo
{
    public class DetailsTaskModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public DetailsTaskModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public TaskPictureVM taskPicVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }
            taskPicVM = new TaskPictureVM();
            taskPicVM.taskModel = await _context.Task
                                                    .Include(t => t.QuotationModel)
                                                        .ThenInclude(q => q.OrderDetailsModel)
                                                    .Include(t => t.Pictures)
                                                    .FirstOrDefaultAsync(m => m.Id == taskId);
            if (taskPicVM == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostPicture()
        {
            var tasklocal = _context.Task.FirstOrDefault(t => t.Id == taskPicVM.taskModel.Id);

            if (tasklocal == null)
            {
                return Page();
            }
            if (tasklocal.Pictures == null)
            {
                tasklocal.Pictures = new List<Picture>();
            }
            using (var memoryStream = new MemoryStream())
            {
                await taskPicVM.Upload.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 8097152)
                {
                    var file = new Picture()
                    {
                        PictureBytes = memoryStream.ToArray()
                    };
                    tasklocal.Pictures.Add(file);
                    //_dbContext.File.Add(file);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            return RedirectToPage("DetailsTask", new { id = tasklocal.Id });
        }
    }
}
