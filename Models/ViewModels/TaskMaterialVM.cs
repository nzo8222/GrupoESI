using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class TaskMaterialVM
    {
        public TaskModel TareaModel { get; set; }
        public Material MaterialModel { get; set; }
        public string taskId { get; set; }
    }
}
