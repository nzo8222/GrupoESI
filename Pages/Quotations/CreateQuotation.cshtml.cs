using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;
using GrupoESINuevo.Models;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Models.ViewModels;

namespace GrupoESINuevo
{
    public class CreateQuotationModel : PageModel
    {
        private readonly GrupoESINuevo.Data.ApplicationDbContext _context;

        public CreateQuotationModel(GrupoESINuevo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      

        [BindProperty]
        public QuotationTaskMaterialVM _OrderQuotationTaskMaterialUserVM { get; set; }
        public Order OrderModel { get; set; }
        public IActionResult OnGet(string orderDetailsId = null)
        {
            if(orderDetailsId == null)
            {
                return Page();
            }
            _OrderQuotationTaskMaterialUserVM = new QuotationTaskMaterialVM()
            {
                QuotationModel = new Quotation(),
                MaterialModel = new Material(),
                taskModel = new TaskModel()
            };
            _OrderQuotationTaskMaterialUserVM.QuotationModel.OrderDetails = _context.OrderDetails.FirstOrDefault(od => od.Id == Int32.Parse(orderDetailsId));
            //_OrderQuotationTaskMaterialUserVM = new OrderQuotationTaskMaterialUserVM
            //{
            //    OrderModel = _context.Order.Include(o => o.Service).ThenInclude(s => s.ApplicationUser).FirstOrDefault(o => o.Id == int.Parse(orderId)),
            //    User = _context.ApplicationUser.FirstOrDefault(u => u.Id == OrderModel.Service.ApplicationUser.Id),
            //    TaskList = new List<System.Threading.Tasks.Task>(),
            //    MaterialList = new List<Material>(),
            //    QuotationModel = new Quotation()
            //};
            //_OrderQuotationTaskMaterialUserVM.OrderModel.Quotations.Add(_OrderQuotationTaskMaterialUserVM.QuotationModel);
            
            //OrderModel.Quotations.Add(QuotationModel); _context.Quotation.Include(q => q.Tasks).Where(t => t.)
            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
