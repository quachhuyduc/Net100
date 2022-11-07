using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDucBTH2.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Data;
using QuachHuyDucBTH2.Models.Process;

namespace QuachHuyDucBTH2.Controllers;

public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;
     private ExcelProcess _excelProcess = new ExcelProcess();
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
    public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName,PersonAddress,PersonEmail,PersonPhone")] Person per)
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
     public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if(fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload");
                }
                else
                {
                    //rename file when upload to server
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Person object
                            var per = new Person();
                            //set values for attributes
                            per.PersonID = dt.Rows[i][0].ToString();
                            per.PersonName = dt.Rows[i][1].ToString();
                            per.PersonAddress = dt.Rows[i][2].ToString();
                            per.PersonPhone = dt.Rows[i][3].ToString();
                            per.PersonEmail = dt.Rows[i][4].ToString();
                            //add object to Context
                            if (!PersonExists(per.PersonID))
                            {
                                _context.Persons.Add(per);    
                            }

                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                    
                }
            }
            return View();
        }

}