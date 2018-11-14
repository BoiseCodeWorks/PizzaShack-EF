using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaShack.Entities
{
    public enum PizzaSize
    {
        Personal = 0,
        Medium = 1,
        Large = 2,
        Family = 3
    }

    public class Pizza
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }
        public ICollection<PizzaTopping> Toppings { get; set; }
    }
}
