using Microsoft.EntityFrameworkCore;
using PizzaShack.Data;
using PizzaShack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShack.Business
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }


        public void CreatePizza(Pizza pizza)
        {
            //do some work business stuff

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public IQueryable<Pizza> GetPizzas()
        {
            //NEVER RETURN IQUERYABLE out of BL OR DBSET
            return _context.Pizzas;
        }
    }
}
