using QuachHuyDucBTH2.Data;
using QuachHuyDucBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuachHuyDucBTH2.Models.Process;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuachHuyDucBTH2.Controllers{
    public class StudentController : Controller{
        private readonly ApplicationDbContext _context;

        private StringProcess strProcess = new StringProcess();

        public StudentController(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var model = await _context.Students.ToListAsync();
            return View(model);
        }

        public IActionResult Create(){
            ViewData["FacultyID"] = new SelectList(_context.Faculty, "FacultyID", "FacultyName");
            var stdID = "STD001";
            var numStudent = _context.Students.Count();
            if(numStudent > 0)
            {
                stdID = _context.Students.OrderByDescending(s => s.StudentID).First().StudentID;
                ViewData["StudentID"] = strProcess.AutoGenerateCode(stdID);
            }
            else
            {
                ViewData["StudentID"] = stdID;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID, StudentName, FacultyID")] Student std){
            if(ModelState.IsValid){
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyID"] = new SelectList(_context.Faculty, "FacultyID", "FacultyName",std.FacultyID);
            ViewData["StudentID"] = std.StudentID;
            return View(std);
        }
        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewData["FacultyID"] = new SelectList(_context.Faculty, "FacultyID", "FacultyName");
            if (id == null)
            {
                return View("NotFound");
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return View("NotFound");
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID, StudentName, FacultyID")] Student std)
        {

            if(id != std.StudentID)
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
                catch(DbUpdateConcurrencyException)
                {
                    if (!StudentExists(std.StudentID))
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
            if(id == null)
            {
                return View("NotFound");
            }
            var std = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if(std == null)
            {
                return View("NotFound");
            }
            return View(std);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var std = await _context.Students.FindAsync(id);
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private ExcelProcess _excelProcess = new ExcelProcess();
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
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
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var emp = new Student();
                            //set values for attributes
                            emp.StudentID = dt.Rows[i][0].ToString();
                             
                            emp.StudentName = dt.Rows[i][1].ToString();
                            emp.FacultyID = dt.Rows[i][2].ToString();
 

                            //add object to Context
                            if (!StudentExists(emp.StudentID))
                            {
                                _context.Students.Add(emp);
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
}