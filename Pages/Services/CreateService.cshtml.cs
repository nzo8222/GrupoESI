using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GrupoESINuevo
{
    [Authorize]
    public class CreateServoceModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ServiceModel Service { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public CreateServoceModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(string userId = null)
        {
            Service = new ServiceModel();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Service.UserId = userId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.ServiceModel.Add(Service);
            await _db.SaveChangesAsync();
            StatusMessage = "El servicio fue creado correctamente";
            return RedirectToPage("IndexService", new { userId = Service.UserId });
        }
    }
}
