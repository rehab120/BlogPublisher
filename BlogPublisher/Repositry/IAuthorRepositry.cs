using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public interface IAuthorRepositry
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        Task Delete(int id);
        //public void SaveCreate(Author auth);
        public void SaveChange(int id, Author author);
    }
}
