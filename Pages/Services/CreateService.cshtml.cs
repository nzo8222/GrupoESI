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
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo
{
    [Authorize]
    public class CreateServoceModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<ServiceType> ServiceTypesList { get; set; }
        [BindProperty]
        public Service Service { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public CreateServoceModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(string userId = null)
        {
            ServiceTypesList = new List<ServiceType>();
            Service = new Service();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Service.UserId = userId;
            //lista de tipos de servicios que ya tienen un servicio registrado
            var servicios = _db.ServiceModel
                                            .Include(s => s.ApplicationUser)
                                            .Include(s => s.serviceType)
                                            .Where(au => au.ApplicationUser.Id == userId).ToList();
            List<Guid> lstTiposDeServiciosConServicioRegistrado = new List<Guid>();

                //_db.ServiceModel
                //                                                 .Include(c => c.serviceType)
                //                                                 .Where(c => c.serviceType == servicios[0].serviceType)
                //                                                 .Select(c => c.ID)
                //                                                 .ToList();

            foreach (var item in servicios)
                {
                lstTiposDeServiciosConServicioRegistrado.Add(item.serviceType.Id);
                }
                
          

            List<Guid> lstDeTiposDeServicios = new List<Guid>();

            var lstTiposDeServicios = _db.ServiceType.ToList();

            foreach (var item in lstTiposDeServicios)
            {
                lstDeTiposDeServicios.Add(item.Id);
            }


            lstDeTiposDeServicios = lstDeTiposDeServicios.FindAll(x => !lstTiposDeServiciosConServicioRegistrado.Contains(x));

            foreach (var item in lstDeTiposDeServicios)
            {
                var _serviceType = _db.ServiceType.FirstOrDefault(s => s.Id == item);
                ServiceTypesList.Add(_serviceType);
            }

            //ServiceTypesList = _db.ServiceType.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Service.serviceType = _db.ServiceType.FirstOrDefault(s => s.Id == Service.serviceType.Id);
            _db.ServiceModel.Add(Service);
            await _db.SaveChangesAsync();
            StatusMessage = "El servicio fue creado correctamente";
            return RedirectToPage("IndexService", new { userId = Service.UserId });
        }
    }
}
