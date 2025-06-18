using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;
using WebApplication1.Repositry;

namespace WebApplication1.Controllers.Entities
{
    public class DepartmentController : Controller
    {
        IDepartmentRepositry Dep1;
        BlogDbContext context;
        public DepartmentController(IDepartmentRepositry _Dep1, BlogDbContext _context)
        {
            Dep1 = _Dep1;
            context = _context;
        }
        // GET: DepartmentController
        public ActionResult GetAll()
        {
            return View("GetAll", Dep1.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            Dep1.Add(department);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var DepId = context.Departments.Include(s => s.author).FirstOrDefault(a => a.Id == id);
            return View(DepId);
        }
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            Dep1.Update(id, department);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id, Department department)
        {
            Dep1.Delete(id, department);
            return RedirectToAction("GetAll");
        }
    }
}
