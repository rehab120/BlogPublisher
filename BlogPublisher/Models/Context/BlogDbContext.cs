using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entites;

namespace WebApplication1.Models.Context
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext() : base() { }
        //inject
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }



    }
}
