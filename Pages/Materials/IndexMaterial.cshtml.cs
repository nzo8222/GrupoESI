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
    public class IndexMaterialModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexMaterialModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public MaterialVM _materialVM { get;set; }

        public async Task OnGetAsync(Guid taskId )
        {
            _materialVM = new MaterialVM();
            _materialVM.taskId = taskId;

            var tareas = await _context.Task
                                            .Include(t => t.ListMaterial)
                                            .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetailsModel)
                                            .FirstOrDefaultAsync(t => t.Id == taskId);
            _materialVM.OrderDetailsId = tareas.QuotationModel.OrderDetailsModel.Id;
            if(tareas == null)
            {
                _materialVM.Material = new List<Material>();
            }
            else
            {
                _materialVM.Material = tareas.ListMaterial;
            }
            

        }
    }
}
