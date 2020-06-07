using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESINuevo
{
    public class EditUserModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public EditUserModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ApplicationUser _ApplicationUser { get; set; }
        public async Task<IActionResult> OnGet(string userId)
        {
            if(userId == "")
            {
                return NotFound();
            }
            _ApplicationUser = _context.ApplicationUser.FirstOrDefault(a => a.Id == userId);
            if(_ApplicationUser == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var ApplicationUserLocal = _context.ApplicationUser.FirstOrDefault(a => a.Id == _ApplicationUser.Id);
            
            if(ApplicationUserLocal == null)
            {
                return NotFound();
            }
            ApplicationUserLocal.Bank = _ApplicationUser.Bank;
            ApplicationUserLocal.City = _ApplicationUser.City;
            ApplicationUserLocal.CompanyName = _ApplicationUser.CompanyName;
            ApplicationUserLocal.Email = _ApplicationUser.Email;
            ApplicationUserLocal.Name = ApplicationUserLocal.Name;
            ApplicationUserLocal.PhoneNumber = _ApplicationUser.PhoneNumber;
            ApplicationUserLocal.RFC = _ApplicationUser.RFC;
            ApplicationUserLocal.SocialReason = _ApplicationUser.SocialReason;
            ApplicationUserLocal.State = _ApplicationUser.State;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                
            }
            return RedirectToPage("Index");
        }
    }
}