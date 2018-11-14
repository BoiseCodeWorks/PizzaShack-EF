using Microsoft.EntityFrameworkCore;
using PizzaShack.Entities;
using System;

namespace PizzaShack.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=den1.mssql8.gear.host;database=pizzashack2;user id=pizzashack2;password=Go34E8E8K_x~");
        }
    }
}
