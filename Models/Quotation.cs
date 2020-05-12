﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class Quotation
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public OrderDetails OrderDetailsModel { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
        public virtual List<Picture> Pictures { get; set; }
    }
}
