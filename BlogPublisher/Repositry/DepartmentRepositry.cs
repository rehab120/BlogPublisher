using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public class DepartmentRepositry : IDepartmentRepositry
    {
        BlogDbContext context;
        public DepartmentRepositry(BlogDbContext _context)
        {
            context = _context;
        }
        public List<Department> GetAll()
        {
            var allDep = context.Departments.Include(s => s.author).ToList();
            return allDep;
        }

        public Department GetById(int id)
        {
            return context.Departments.Include(s => s.author).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Department dep)
        {
            Department department = new Department();
            department.Name = dep.Name;
            department.CreateTime = dep.CreateTime;
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void Update(int id, Department dep)
        {
            var DepId = GetById(id);
            DepId.Name = dep.Name;
            DepId.CreateTime = dep.CreateTime;
            context.Departments.Update(DepId);
            context.SaveChanges();
        }

        public void Delete(int id, Department department)
        {
            var Dep = context.Departments.Include(s => s.author).FirstOrDefault(a => a.Id == department.Id);
            context.Departments.Remove(Dep);
            context.SaveChanges();
        }
    }
}
