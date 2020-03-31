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
using GrupoESINuevo.Models.ViewModels;
using System.Security.Claims;

namespace GrupoESINuevo
{
    [Authorize]
    public class IndexServiceModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        [BindProperty]
        public ServiceAndProviderVM ServiceAndProviderVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexServiceModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(string userId = null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }


            ServiceAndProviderVM = new ServiceAndProviderVM()
            {
                Services = await _db.ServiceModel.Where(c => c.ApplicationUser.Id == userId).ToListAsync(),
                UserObj = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)
            };

            return Page();
        }
    }
}
