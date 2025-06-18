using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;
using WebApplication1.Repositry;

namespace WebApplication1.Controllers.Entities
{
    public class AuthorController : Controller
    {
        IAuthorRepositry author1;
        BlogDbContext context;
        public AuthorController(IAuthorRepositry _author1, BlogDbContext _context)
        {
            author1 = _author1;
            context = _context;
           
        }
        // [Route("Auth/get")]
        [Authorize]
        public ActionResult GetAll()
        {

            return View("GetAll", author1.GetAll());
        }
        public ActionResult GetById(int id)
        {
            var authorId = author1.GetById(id);
            return View(authorId);
        }

        public ActionResult Create()
        {
            ViewBag.Department = context.Departments.ToList();
            ViewBag.Post = context.Posts.ToList();
            return View();
        }

        //public ActionResult Add(Author author)
        //{
        //    author1.SaveCreate(author);
        //    return RedirectToAction("GetAll");
        //}

        public async Task<ActionResult> Delete(int id)
        {
            await author1.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var authorE = context.Authors.Include(s => s.department).FirstOrDefault(e => e.Id == id);
            ViewBag.Department = context.Departments.ToList();
            ViewBag.Post = context.Posts.ToList();
            return View(authorE);
        }
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            author1.SaveChange(id, author);
            return RedirectToAction("GetById", new { Id = author.Id });
        }
    }
}
