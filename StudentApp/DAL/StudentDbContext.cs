using Microsoft.EntityFrameworkCore;
using StudentApp.Models.DBEntities;

namespace StudentApp.DAL
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }   
        
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void Update(Student student)
        {
            Students.Update(student);
        }
        public void Delete(int id)
        {
            Students.Remove(id);
        }
    }
}
