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
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Thriller", DisplayOrder = 2 },
             new Category { Id = 3, Name = "Fiction", DisplayOrder = 3 }
        );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Title = "Dragon Ball Z, Vol. 8", Description= "Forced to ally with Vegeta against their common enemy, Gohan and Kuririn fight desperately against Freeza's elite troops, the seemingly unstoppable Ginyu Force! But the tables may be turning as Son Goku finally arrives on Planet Namek, his strength and speed increased ten-fold by training under 100 times Earth's gravity! Could Goku have become the legendary \"Super Saiyan\"!? And even if they defeat Captain Ginyu, can they prevent Freeza from wishing for immortality on the Dragon Balls--and Vegeta from betraying them and doing the same?", ISBN = "12345678", Author = "Akira Toriyama", ListPrice = 20, Price = 20, Price50 = 10, Price100 = 5, CategoryId = 1, ImageUrl="" },
            new Product { Id = 1, Title = "Baki-Dou, Vol. 6", Description = "Baki", ISBN = "12345679", Author = "KEISUKE ITAGAKI", ListPrice = 30, Price = 30, Price50 = 20, Price100 = 15, CategoryId = 1, ImageUrl="" },
            new Product { Id = 1, Title = "BAKI, Vol. 25", Description = "the embodiment of self-defense, goes up against the awe-inspiring jewel of the 4,000-year history of Chinese martial arts, Sea King Retsu!! Attack Vs. defense...Which tactic will prevail?!", ISBN = "12345679", Author = "KEISUKE ITAGAKI", ListPrice = 30, Price = 30, Price50 = 20, Price100 = 15, CategoryId = 1, ImageUrl="" },
            new Product { Id = 1, Title = "Jujutsu Kaisen, Vol. 4", Description = "While investigating a strange set of mysterious deaths, Itadori meets Junpei, a troubled kid who is often bullied at school. However, Junpei is also befriended by the culprit behind the bloody incident—Mahito, a mischievous cursed spirit! Mahito sets in motion a devious plan involving Junpei, hoping to ensnare Itadori as well.", ISBN = "12345679", Author = "Gege Akutami", ListPrice = 30, Price = 30, Price50 = 20, Price100 = 15, CategoryId = 1, ImageUrl="" }
            );
        }
    }
}
