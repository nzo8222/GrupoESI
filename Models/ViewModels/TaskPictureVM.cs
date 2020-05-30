using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class TaskPictureVM
    {
        public TaskModel taskModel { get; set; }

        public IFormFile Upload { get; set; }
        public TaskPictureVM()
        {
            taskModel = new TaskModel();
        }
    }
}
