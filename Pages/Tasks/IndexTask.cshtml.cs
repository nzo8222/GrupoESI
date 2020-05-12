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
    public class IndexModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskModel> TaskModel { get;set; }
        public TaskMaterialVM _taskMaterialVM { get; set; }
        public async Task OnGetAsync()
        {

            TaskModel = await _context.Task.ToListAsync();
        }
    }
}
