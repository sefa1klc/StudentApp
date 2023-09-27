using Microsoft.AspNetCore.Mvc;
using StudentApp.DAL;
using StudentApp.Models;
using StudentApp.Models.DBEntities;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _studentDbContext.Students.ToList();
            List<StudentViewModel> studentList = new List<StudentViewModel>();

            if (students.Any())
            {
                foreach (var student in students)
                {
                    studentList.Add(new StudentViewModel { Id=student.Id, FirstName=student.FirstName, LastName=student.LastName, Email=student.Email });
                }
            }

            return View(studentList);
        }

        [HttpPost]
        public IActionResult Insert(Student student)
        {
            _studentDbContext.AddStudent(student);  
            
            
            return View();
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            _studentDbContext.Update(student);


            return View();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentDbContext.Remove(id);


            return View();
        }
    }
}
