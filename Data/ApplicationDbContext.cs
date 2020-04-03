using System;
using System.Collections.Generic;
using System.Text;
using GrupoESINuevo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Service> ServiceModel { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Material> Material { get; set; }
    }
}
