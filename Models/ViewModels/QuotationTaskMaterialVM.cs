using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class QuotationTaskMaterialVM
    {
        public Quotation QuotationModel { get; set; }
        public TaskModel taskModel { get; set; }
        public Material MaterialModel { get; set; }
        public Guid orderDetailsId { get; set; }
        public List<Material> lstMaterial { get; set; }
        public List<TaskModel> lstTaskModel { get; set; }
    }
}
