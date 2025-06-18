using Microsoft.Extensions.Hosting;
using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public interface IPostRepositry
    {
         List<Post> GetAll();
         Post GetById(int id);
         void Add(Post post);
         void Update(int id, Post post);
         void Delete(int id, Post post);
         List<Post> Search(string postType);
        //void FavItem(int id, Post post);
    }
}
