using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "SciFi", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Horror", DisplayOrder = 2 },
             new Category { Id = 3, Name = "Fiction", DisplayOrder = 3 }
        );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Title = "Can't Hurt me", Description="David Goggins story", ISBN = "12345678", Author = "David Goggins", ListPrice = 20, Price = 20, Price50 = 10, Price100 = 5, CategoryId = 1, ImageUrl="" },
            new Product { Id = 2, Title = "Discipline Is The Destiny", Description = "Book about discipline", ISBN = "12345679", Author = "Ryan Holiday", ListPrice = 30, Price = 30, Price50 = 20, Price100 = 15, CategoryId = 2, ImageUrl="" }

            );
        }
    }
}
