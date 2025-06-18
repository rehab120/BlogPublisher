using WebApplication1.Models.Entites;

namespace WebApplication1.Repositry
{
    public interface IDepartmentRepositry
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department dep);
        public void Update(int id, Department dep);
        public void Delete(int id, Department department);
    }
}
