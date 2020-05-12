using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class AddServiceVM
    {
        public Guid orderId { get; set; }
        public Guid serviceId { get; set; }
        public List<Service> lstServicios { get; set; }
        public AddServiceVM(Guid orderIdlocal)
        {
            orderId = orderIdlocal;
            lstServicios = new List<Service>();
            serviceId = Guid.NewGuid();
        }
        public AddServiceVM()
        {

        }
    }
}
