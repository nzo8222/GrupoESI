using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using GrupoESINuevo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo
{
    public class CreateModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public CreateModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        
        [BindProperty]
        public TaskQuotationVM _TaskQuotationVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {
            _TaskQuotationVM = new TaskQuotationVM(orderDetailsId);
            //_TaskQuotationVM.orderDetailsId = orderDetailsId;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _TaskQuotationVM.TaskLocal.Cost = _TaskQuotationVM.TaskLocal.CostHandLabor;
            var quotation = _context.Quotation
                                            .Include(q => q.Tasks)
                                            .Include(q => q.OrderDetailsModel)
                                            .Where(q => q.OrderDetailsModel.Id == _TaskQuotationVM.orderDetailsId).ToList();
            if (quotation.Count == 0)
            {
                quotation = new List<Quotation>();
                quotation.Add(new Quotation());
                quotation[0].OrderDetailsModel = _context.OrderDetails.FirstOrDefault(od => od.Id == _TaskQuotationVM.orderDetailsId);
                quotation[0].Tasks = new List<TaskModel>();
                
                quotation[0].Tasks.Add(_TaskQuotationVM.TaskLocal);
                _context.Quotation.Add(quotation[0]);
            }
            else
            {
                quotation[0].Tasks.Add(_TaskQuotationVM.TaskLocal);
                _context.Quotation.Update(quotation[0]);
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = _TaskQuotationVM.orderDetailsId });
            //return RedirectToPage("./Index");
        }
    }
}
