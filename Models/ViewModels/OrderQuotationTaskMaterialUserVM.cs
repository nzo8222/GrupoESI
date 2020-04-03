using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class OrderQuotationTaskMaterialUserVM
    {
        public Order OrderModel { get; set; }
        public Quotation QuotationModel { get; set; }
        public List<System.Threading.Tasks.Task> TaskList { get; set; }
        public List<Material> MaterialList { get; set; }
        public ApplicationUser User { get; set; }
    }
}
