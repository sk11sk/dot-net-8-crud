using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentManagementSystem.Data;
using studentManagementSystem.Models;
using studentManagementSystem.Models.Entities;
using System.Security.Cryptography;

namespace studentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext )
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students =studentDbContext.Students.ToList();

            return Ok(new { students, message = "Get all students"});
        }

        [HttpPost]
        public IActionResult saveStudent(AddStudentDto addStudentDto) {

            var studentEntity = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName
            };


            studentDbContext.Students.Add(studentEntity);

            studentDbContext.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("{id:long}")]
        public IActionResult updateStudent(long id,AddStudentDto addStudentDto)
        {


            var student = studentDbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }
            student.FirstName = addStudentDto.FirstName;
            student.LastName = addStudentDto.LastName;
            studentDbContext.SaveChanges();
            return Ok();
        }


        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetStudent(long id)
        {
            var student = studentDbContext.Students.Find(id);

            if (student is null) {
                return NotFound();
            }

            return Ok(new { student, message = "Get  student" });
        }


        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult deleteStudent(long id)

        {
            var student = studentDbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

             studentDbContext.Students.Remove(student);
            studentDbContext.SaveChanges();

            return Ok(new { student, message = "student  deleted by id " + id });
        }


    }
}
