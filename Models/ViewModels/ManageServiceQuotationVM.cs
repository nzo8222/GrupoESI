using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class ManageServiceQuotationVM
    {
        public Service ServiceModel { get; set; }
        public bool sendQuotation { get; set; }
    }
}
