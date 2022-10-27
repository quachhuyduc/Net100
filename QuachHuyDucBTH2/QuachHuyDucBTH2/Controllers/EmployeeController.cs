using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDucBTH2.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Data;

namespace QuachHuyDucBTH2.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    public EmployeeController (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _context.Employees.ToListAsync();
        return View(model);
    }
       public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employee emp){
          if(ModelState.IsValid){
            _context.Add(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }
          return View(emp);
    }
    private bool EmployeeExists(String id)
    {
        return _context.Employees.Any(e => e.EmployeeID == id);
    }
    public async Task<IActionResult> Edit (String id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var employee = await _context.Employees.FindAsync(id);
        if(employee == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(employee);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployeeName")] Employee emp)
    {
          if(id != emp.EmployeeID)
          {
            //return NotFound();
            return View("NotFound");
          }
          if (ModelState.IsValid)
          {
            try 
            {
                _context.Update(emp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!EmployeeExists(emp.EmployeeID))
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
          return View(emp);
    }
    public async Task<IActionResult> Delete(string id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var emp = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);
        if(emp == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(emp);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(string id)
     {
        var emp = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(emp);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

     }


}