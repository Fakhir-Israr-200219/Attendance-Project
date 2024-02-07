using Attendance_Project.Core.Interface;
using Attendance_Project.data;
using Attendance_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Project.Core.Implemantation
{
    public class StudentRepo : IStudentRepo<Student>
    {
        private readonly AttendanceProContext context;
        public StudentRepo(AttendanceProContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddStudent(Student Stu)
        {
            await context.Students.AddAsync(Stu);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var test = await context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (test == null) return false;
            if (test.StudentId == id)
            {
                context.Students.Remove(test);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudend()
        {
            return (await context.Students.ToListAsync());
        }

        public async Task<Student> GetStudentByID(int id)
        {
            var test = await context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (test == null)
            {
                return new Student { StudentId = -1, FirstName = "Student not found" };
            }
            return test;
        }

        public async Task<bool> UpdateStudent(Student Stu)
        {
            var test = await context.Students.FirstOrDefaultAsync(x => x.StudentId == Stu.StudentId);
            if (test == null) return false;
            if (test.StudentId == Stu.StudentId)
            {
                context.Students.Update(Stu);
                context.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
