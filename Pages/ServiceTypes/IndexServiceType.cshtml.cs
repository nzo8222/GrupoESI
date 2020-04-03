using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Authorization;
using GrupoESINuevo.Uitility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexServiceTypeModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexServiceTypeModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServiceType> ServiceType { get;set; }

        public async Task OnGetAsync()
        {
            ServiceType = await _context.ServiceType.ToListAsync();
        }
    }
}
