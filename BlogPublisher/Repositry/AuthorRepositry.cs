using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public class AuthorRepositry : IAuthorRepositry
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly SignInManager<ApplicationUser> signInManager;
        BlogDbContext context;
        public AuthorRepositry(BlogDbContext _context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManger = userManager;
            this.signInManager = signInManager;
            context = _context;
        }

        public List<Author> GetAll()
        {
            var allAuthor = context.Authors.Include(s => s.department).ToList();
            return allAuthor;
        }

        public Author GetById(int id)

        {
            return context.Authors.Include(a => a.department).FirstOrDefault(s => s.Id == id);
        }

        //public void SaveCreate(Author auth)
        //{
        //    Author author = new Author();
        //    author.Name = auth.Name;
        //    author.EmailAddress = auth.EmailAddress;
        //    author.BirthDate = auth.BirthDate;
        //    author.Gender = auth.Gender;
        //    author.Salary = auth.Salary;
        //    author.Address = auth.Address;
        //    author.Dep_id = auth.Dep_id;
        //    // author.Post_id = auth.Post_id;
        //    context.Authors.Add(author);
        //    context.SaveChanges();


        //}

        public void SaveChange(int id, Author author)
        {
            var AuthorId = GetById(id);
            AuthorId.Name = author.Name;
            AuthorId.EmailAddress = author.EmailAddress;
            AuthorId.BirthDate = author.BirthDate;
            AuthorId.Gender = author.Gender;
            AuthorId.Salary = author.Salary;
            AuthorId.Address = author.Address;
            AuthorId.Dep_id = author.Dep_id;
            //   AuthorId.Post_id=author.Post_id;
            context.Authors.Update(AuthorId);
            context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var author = await context.Authors.Include(a => a.department).FirstOrDefaultAsync(a => a.Id == id);

            if (author != null)
            {
                var userModel = await userManger.FindByEmailAsync(author.EmailAddress);
                if (userModel != null)
                {
                    IdentityResult result = await userManger.DeleteAsync(userModel);
                    if (result.Succeeded)
                    {
                        context.Authors.Remove(author);
                        await context.SaveChangesAsync(); // Await SaveChangesAsync here
                    }
                }
                else
                {
                    context.Authors.Remove(author);
                    await context.SaveChangesAsync(); // Await SaveChangesAsync here too
                }
            }
        }


    }
}
