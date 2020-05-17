using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class MaterialVM
    {
        public Guid OrderDetailsId { get; set; }
        public IList<Material> Material { get; set; }
        public Guid taskId { get; set; }
        public MaterialVM()
        {
            Material = new List<Material>();
        }
    }
}
