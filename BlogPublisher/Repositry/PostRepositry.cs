using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public class PostRepositry : IPostRepositry
    {
        BlogDbContext context;
        public PostRepositry(BlogDbContext _context)
        {
            context = _context;
        }
        public List<Post> GetAll()
        {
            var allPost = context.Posts.Include(s => s.Author).OrderByDescending(s => s.CreateTime).ToList();
            return allPost;
        }

        public Post GetById(int id)
        {
            return context.Posts.Include(s => s.Author).FirstOrDefault(s => s.Id == id);
        }

        public void Add(Post post)
        {
            Post postN = new Post();
            postN.Id = post.Id;
            postN.Type = post.Type;
            postN.Descripation = post.Descripation;
            postN.CreateTime = post.CreateTime;
            postN.Image = post.Image;
            postN.Author_id = post.Author_id;
            context.Posts.Add(postN);
            context.SaveChanges();
        }

        public void Update(int id, Post post)
        {
            var postN = GetById(id);
            postN.Type = post.Type;
            postN.Descripation = post.Descripation;
            postN.CreateTime = post.CreateTime;
            postN.Image = post.Image;
            context.Posts.Update(postN);
            context.SaveChanges();
        }

        public void Delete(int id, Post post)
        {
            var PostId = context.Posts.Include(s => s.Author).FirstOrDefault(s => s.Id == post.Id);
            context.Posts.Remove(PostId);
            context.SaveChanges();

        }

        public List<Post> Search(string postType)
        {
            return context.Posts.Include(s=>s.Author).Where(s=>s.Type==postType).ToList();
        }

        //public void FavItem(int id, Post post)
        //{
        //    var FavId = context.Posts.Include(s => s.Author).FirstOrDefault(s => s.Id == post.Id);
        //    if(FavId != null)
        //    {
        //        FavId.IsFav = !(FavId.IsFav ?? false);
        //        context.SaveChanges();
        //    }

        //}
    }
}
