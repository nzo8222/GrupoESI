﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class TaskModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
        public double CostHandLabor { get; set; }

        public virtual List<Material> ListMaterial { get; set; }
        public  Quotation QuotationModel { get; set; }

        public virtual List<Picture> Pictures { get; set; }

    }
}
