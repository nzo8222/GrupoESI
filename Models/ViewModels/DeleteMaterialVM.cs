using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class DeleteMaterialVM
    {
        public Material material { get; set; }
        public Guid taskId { get; set; }
        public DeleteMaterialVM()
        {
            material = new Material();
        }
    }
}
