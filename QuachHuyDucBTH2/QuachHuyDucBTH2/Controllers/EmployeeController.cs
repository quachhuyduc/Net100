using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDucBTH2.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Data;
using QuachHuyDucBTH2.Models.Process;



namespace QuachHuyDucBTH2.Controllers;

 public class EmployeeController : Controller{
        private readonly ApplicationDbContext _context;

        private ExcelProcess _excelProcess = new ExcelProcess();

        public EmployeeController(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var model = await _context.Employees.ToListAsync();
            return View(model);
        }

        public IActionResult Create(){
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

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return View("NotFound");
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID, EmployeeName, EmployeeAddress, EmployeeEmail, EmployeePhone")] Employee std)
        {
            if (id != std.EmployeeID)
            {
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(std);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(std.EmployeeID))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            var std = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (std == null)
            {
                return View("NotFound");
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var std = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(std);
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
                            //create a new Employee object
                            var emp = new Employee();
                            //set values for attributes
                            emp.EmployeeID = dt.Rows[i][0].ToString();
                            emp.EmployeeName = dt.Rows[i][1].ToString();
                            emp.EmployeeAddress = dt.Rows[i][2].ToString();
                            emp.EmployeePhone = dt.Rows[i][3].ToString();
                            emp.EmployeeEmail = dt.Rows[i][4].ToString();
                            //add object to Context
                            if (!EmployeeExists(emp.EmployeeID))
                            {
                                _context.Employees.Add(emp);    
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
