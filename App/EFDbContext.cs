using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PresentationDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var priceGenerator = new RandomGenerator();

            var products = Builder<Product>.CreateListOfSize(25000)
                .All()
                    .With(p => p.Name = "Product " + p.Id.ToString())
                    .With(p => p.Price = priceGenerator.Next(250, 500))
                .Build();

            foreach (var item in products)
            {
                modelBuilder.Entity<Product>().HasData(
                    new Product { Id = item.Id, Name = item.Name, Price = item.Price });
            }
        }
    }
}
