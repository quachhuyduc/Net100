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

}