using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESINuevo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string RFC { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        public string SocialReason { get; set; }
        public string Bank { get; set; }
    }
}
