using Eatstead.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Domain;
using Microsoft.Extensions.Hosting;

namespace Valuegate.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Menu>()
            .HasOne(m => m.Cafeteria)
            .WithMany(c => c.Menus)
            .HasForeignKey(m => m.CafeteriaId);

            builder.Entity<Cafeteria>()
                .HasMany(r => r.Menus)
                .WithOne(h => h.Cafeteria)
                .HasForeignKey(h => h.CafeteriaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Cafeteria> Cafeterias { get; set; }
        public DbSet<Menu> Menus { get; set; }
        

    }
}
