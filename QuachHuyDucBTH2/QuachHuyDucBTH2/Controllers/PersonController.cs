using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDucBTH2.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Data;

namespace QuachHuyDucBTH2.Controllers;

public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;
    public PersonController (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _context.Persons.ToListAsync();
        return View(model);
    }
       public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Person per){
          if(ModelState.IsValid){
            _context.Add(per);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }
          return View(per);
    }
     private bool PersonExists(String id)
    {
        return _context.Persons.Any(e => e.PersonID == id);
    }
    public async Task<IActionResult> Edit (String id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var person = await _context.Persons.FindAsync(id);
        if(person == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(person);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName")] Person per)
    {
          if(id != per.PersonID)
          {
            //return NotFound();
            return View("NotFound");
          }
          if (ModelState.IsValid)
          {
            try 
            {
                _context.Update(per);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!PersonExists(per.PersonID))
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
          return View(per);
    }
    public async Task<IActionResult> Delete(string id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var per = await _context.Persons.FirstOrDefaultAsync(m => m.PersonID == id);
        if(per == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(per);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(string id)
     {
        var per = await _context.Persons.FindAsync(id);
        _context.Persons.Remove(per);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

     }

}