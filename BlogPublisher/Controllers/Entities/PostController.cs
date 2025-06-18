using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;
using WebApplication1.Repositry;

namespace WebApplication1.Controllers.Entities
{
    public class PostController : Controller
    {
        IPostRepositry post1;
        BlogDbContext context;
        public PostController(IPostRepositry _post1, BlogDbContext _context)
        {
            post1 = _post1;
            context = _context;
        }
        public ActionResult GetAll()
        {
            return View("GetAll", post1.GetAll());
        }

        public ActionResult GetById(int id)
        {
            var postt = post1.GetById(id);
            return View(postt);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Author = context.Authors.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post postC)
        {
            post1.Add(postC);
            return RedirectToAction("GetAll");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Author = context.Authors.ToList();
            var authorE = context.Posts.Include(s => s.Author).FirstOrDefault(e => e.Id == id);
            return View(authorE);
        }
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            post1.Update(id, post);
            return RedirectToAction("GetById", new { Id = post.Id });
        }

        public ActionResult Delete(int id, Post postC)
        {
            post1.Delete(id, postC);
            return RedirectToAction("GetAll");

        }

        // GET: Search form and filtered results
        //[HttpGet]
        //public ActionResult Find(string type)
        //{
        //    ViewData["type"] = type;
        //    if (!string.IsNullOrEmpty(type))
        //    {
        //        var posts = post1.Search(type);
        //        return View(posts);  // Pass the search result to the view
        //    }
        //    return View();  // If no search, just return the empty view
        //}

        // POST: Search by type (if you want to submit the form via POST)
        [HttpPost]
        public ActionResult FindPost(string type)
        {
            var posts = post1.Search(type);
            return View(posts);  // Return the search results
        }
        //[HttpGet]
        //public ActionResult Fav()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Fav(int id , Post post)
        //{
        //    post1.FavItem(id, post);
        //    return View();
        //}

       




    }
}
