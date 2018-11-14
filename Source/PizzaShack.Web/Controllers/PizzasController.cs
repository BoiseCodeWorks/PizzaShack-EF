using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using PizzaShack.Business;
using PizzaShack.Data;
using PizzaShack.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PizzaShack.Web.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaService _ps;

        public PizzasController(PizzaService ps)
        {
            _ps = ps;
        }

        // GET: Pizzas
        public IActionResult Index()
        {
            return View(_ps.GetPizzas());
        }

        [HttpGet("~/api/pizzas")]
        public IActionResult GetPizzas()
        {
            var results = _ps.GetPizzas().Select(x => new
            {
                x.Id,
                x.Name,
                x.Description,
                x.Size,
                x.Price,
                Toppings = x.Toppings.Select(a => a.Topping.Name),
            });

            return Ok(results);
        }

        // GET: Pizzas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pizza = await _context.Pizzas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pizza == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pizza);
        //}

        //// GET: Pizzas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Pizzas/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Size")] Pizza pizza)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pizza);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pizza);
        //}

        //// GET: Pizzas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pizza = await _context.Pizzas.FindAsync(id);
        //    if (pizza == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pizza);
        //}

        //// POST: Pizzas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Size")] Pizza pizza)
        //{
        //    if (id != pizza.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pizza);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PizzaExists(pizza.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pizza);
        //}

        //// GET: Pizzas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pizza = await _context.Pizzas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pizza == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pizza);
        //}

        //// POST: Pizzas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pizza = await _context.Pizzas.FindAsync(id);
        //    _context.Pizzas.Remove(pizza);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PizzaExists(int id)
        //{
        //    return _context.Pizzas.Any(e => e.Id == id);
        //}
    }
}
