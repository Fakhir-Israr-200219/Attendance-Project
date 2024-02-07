using Attendance_Project.Core.Implemantation;
using Attendance_Project.Core.Interface;
using Attendance_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo<Student> IStuRepo;
        public StudentController(IStudentRepo<Student> _IstuRepo)
        {
            IStuRepo = _IstuRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var data = await IStuRepo.GetAllStudend();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GEtStudentById(int id)
        {
            var data = await IStuRepo.GetStudentByID(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student Stu)
        {
            var data = await IStuRepo.AddStudent(Stu);
            if (data)
            {
                return Ok("Data is inserted");
            }
            else
            {
                return Ok(NotFound());
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student Stu)
        {
            var data = await IStuRepo.UpdateStudent(Stu);
            if (data == null) return BadRequest();
            if (data)
            {
                return Ok("data is Updated");
            }
            else
            {
                return Ok(NotFound());
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var data =await IStuRepo.DeleteStudent(id);
            if (data)
            {
                return Ok("data is delete");
            }
            else
            {
                return Ok(NotFound());
            }
        }
    }
}
