using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESINuevo.Models;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Models.ViewModels;
using GrupoESINuevo.Uitility;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GrupoESINuevo
{
    public class CreateQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public CreateQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        [BindProperty]
        public QuotationTaskMaterialVM _QuotationTaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {
            if(orderDetailsId == null)
            {
                return Page();
            }
            
            var quotationlocal = _context.Quotation
                                                    .Include(q => q.OrderDetailsModel)
                                                        .ThenInclude(q => q.Order)
                                                    .Include(q =>q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                        .FirstOrDefault(q => q.OrderDetailsModel.Id == orderDetailsId);

            var userOD = _context.OrderDetails
                                              .Include(od => od.Order)
                                              .Include(od => od.Service)
                                                 .ThenInclude(s => s.ApplicationUser)
                                                 .FirstOrDefault(od => od.Id == orderDetailsId);

            var orderDetailsServicesSameUser = _context.OrderDetails
                                                                    .Include(od => od.Order)
                                                                    .Include(od => od.Service)
                                                                         .ThenInclude(s => s.ApplicationUser)
                                                                         .Where(od => od.Service.ApplicationUser.Id == userOD.Service.ApplicationUser.Id && od.Order.Id == userOD.Order.Id).ToList();
           
            if (quotationlocal == null)
            {
                _QuotationTaskMaterialVM = new QuotationTaskMaterialVM(orderDetailsId);
                _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel = _context.OrderDetails.Include(od => od.Order).FirstOrDefault(od => od.Id == orderDetailsId);
            }
            else
            {
                var listaTareaslocal = quotationlocal.Tasks;
                if (listaTareaslocal == null)
                {
                    _QuotationTaskMaterialVM = new QuotationTaskMaterialVM(orderDetailsId, quotationlocal);
                }
                else
                {
                    var listaMaterialesLocal = new List<Material>();
                    
                    foreach (var item in listaTareaslocal)
                    {
                        var listaMaterialesDentroDelForEach = item.ListMaterial.ToList();
                        foreach (var objetoMaterial in listaMaterialesDentroDelForEach)
                        {
                            listaMaterialesLocal.Add(objetoMaterial);
                        }
                    };
                    if(listaMaterialesLocal.Count() > 0)
                    {
                        _QuotationTaskMaterialVM = new QuotationTaskMaterialVM(orderDetailsId, quotationlocal, listaTareaslocal, listaMaterialesLocal);
                    }
                    else
                    {
                        _QuotationTaskMaterialVM = new QuotationTaskMaterialVM(orderDetailsId, quotationlocal, listaTareaslocal);
                    }
                   
                }
                foreach (var item in orderDetailsServicesSameUser)
                {
                    _QuotationTaskMaterialVM.lstOrderDetailsSameUserServices.Add(item);
                }
            }

            

            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.orderDetailsId });
            //}
            var quotation = _context.Quotation
                                                .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.ListMaterial)
                                                .Include(q => q.OrderDetailsModel)
                                                .ThenInclude(od => od.Order)
                                                .FirstOrDefault(q => q.Id == _QuotationTaskMaterialVM.QuotationModel.Id);

            if(quotation.Tasks.Count == 0)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.orderDetailsId });
            }
            quotation.Description = _QuotationTaskMaterialVM.QuotationModel.Description;

            foreach (var item in quotation.Tasks)
            {
                quotation.OrderDetailsModel.Cost =+ item.Cost;
                foreach (var item2 in item.ListMaterial)
                {
                    quotation.OrderDetailsModel.Cost =+ item2.Price;
                }
            }



            
            _context.Quotation.Update(quotation);
            var order = _context.Order.FirstOrDefault(o => o.Id == quotation.OrderDetailsModel.Order.Id);
            order.EstadoDelPedido = SD.EstadoCotizado;
             _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexQuotation");
        }


        

        //public async Task<IActionResult> OnPostDeletePicture()
        //{
        //    var quotationWithPictures = await _context.Quotation
        //                                           .Include(q => q.Pictures)
        //                                           .FirstOrDefaultAsync(q => q.Id == _QuotationTaskMaterialVM.QuotationModel.Id);
        //    if(quotationWithPictures != null)
        //    {
        //        if(quotationWithPictures.Pictures.Count > 0)
        //        {
        //            try
        //            {
        //                var picture = quotationWithPictures.Pictures.Find(p => p.PictureId == _QuotationTaskMaterialVM.QuotationModel.Picture)
        //                quotationWithPictures.Pictures.Remove()
        //            }
        //        }
        //    }
        //    return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel.Id });
        //}

    }
}
