using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDucBTH2.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Data;

namespace QuachHuyDucBTH2.Controllers;

public class CustomerController : Controller
{
    private readonly ApplicationDbContext _context;
    public CustomerController (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _context.Customers.ToListAsync();
        return View(model);
    }
       public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Customer cus){
          if(ModelState.IsValid){
            _context.Add(cus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }
          return View(cus);
    }
    private bool CustomerExists(String id)
    {
        return _context.Customers.Any(e => e.CustomerID == id);
    }
    public async Task<IActionResult> Edit (String id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var customer = await _context.Customers.FindAsync(id);
        if(customer == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(customer);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("CustomerID,CustomerName")] Customer cus)
    {
          if(id != cus.CustomerID)
          {
            //return NotFound();
            return View("NotFound");
          }
          if (ModelState.IsValid)
          {
            try 
            {
                _context.Update(cus);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CustomerExists(cus.CustomerID))
                {
                    //return NotFound();
                    return View("NotFound");
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
          }
          return View(cus);
    }
     public async Task<IActionResult> Delete(string id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var cus = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);
        if(cus == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(cus);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(string id)
     {
        var cus = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(cus);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

     }


}