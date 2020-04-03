using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class ServiceAndProviderVM
    {
        public ApplicationUser UserObj { get; set; }
        public List<Service> Services { get; internal set; }
        //public IEnumerable<ServiceModel> Services { get; set; }
    }
}
