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
    public class IndexQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public IndexQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Quotation> Quotation { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Quotation = await _context.Quotation.ToListAsync();
        }
    }
}
