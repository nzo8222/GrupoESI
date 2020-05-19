using Microsoft.AspNetCore.Http;
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
        public List<OrderDetails> lstOrderDetailsSameUserServices { get; set; }
        public List<Material> lstMaterial { get; set; }
        public List<TaskModel> lstTaskModel { get; set; }
        public IFormFile Upload { get; set; }
        public QuotationTaskMaterialVM()
        {

        }
        public QuotationTaskMaterialVM(Guid id)
        {
            QuotationModel = new Quotation();
            taskModel = new TaskModel();
            MaterialModel = new Material();
            orderDetailsId = id;
            lstMaterial = new List<Material>();
            lstTaskModel = new List<TaskModel>();
            lstOrderDetailsSameUserServices = new List<OrderDetails>();
        }
        public QuotationTaskMaterialVM(Guid id, Quotation quotation)
        {
            QuotationModel = quotation;
            taskModel = new TaskModel();
            MaterialModel = new Material();
            orderDetailsId = id;
            lstMaterial = new List<Material>();
            lstTaskModel = new List<TaskModel>();
            lstOrderDetailsSameUserServices = new List<OrderDetails>();
        }
        public QuotationTaskMaterialVM(Guid id, Quotation quotation, List<TaskModel> tasks, List<Material> materials)
        {
            QuotationModel = quotation;
            taskModel = new TaskModel();
            MaterialModel = new Material();
            orderDetailsId = id;
            lstMaterial = materials;
            lstTaskModel = tasks;
            lstOrderDetailsSameUserServices = new List<OrderDetails>();
        }
        public QuotationTaskMaterialVM(Guid id, Quotation quotation, List<TaskModel> tasks)
        {
            QuotationModel = quotation;
            taskModel = new TaskModel();
            MaterialModel = new Material();
            orderDetailsId = id;
            lstTaskModel = tasks;
            lstOrderDetailsSameUserServices = new List<OrderDetails>();
        }
    }
}
