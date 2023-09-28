using mvc3.Models;
using System.Linq;
using System.Web.Mvc;

namespace mvc3.Controllers
{
    public class StudentController : Controller
    {
        private mvc3Entities _context = new mvc3Entities();

        // GET: Student
        public ActionResult Index()
        {
            return View(_context.Students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["Faculties"] = _context.Faculties;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            var found = _context.Students.Where(e => e.Id == student.Id).ToList().FirstOrDefault();
            if (found != null)
            {
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.ServiceUnavailable);
                ViewData["Faculties"] = _context.Faculties;
                return View();
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}