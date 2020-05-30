using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models.ViewModels
{
    public class TaskQuotationVM
    {
        public Guid orderDetailsId { get; set; }
        public TaskModel TaskLocal { get; set; }


        public TaskQuotationVM()
        {

        }
        public TaskQuotationVM(Guid id)
        {
            TaskLocal = new TaskModel();
            orderDetailsId = id;
        }
        
    }
}
