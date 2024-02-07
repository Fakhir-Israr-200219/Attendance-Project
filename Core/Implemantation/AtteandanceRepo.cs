using Attendance_Project.Core.Interface;
using Attendance_Project.data;
using Attendance_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Project.Core.Implemantation
{
    public class AtteandanceRepo : IAttendanceRepo<Attendance>
    {
        private readonly AttendanceProContext context;
        public AtteandanceRepo(AttendanceProContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddAttendance(Attendance Att)
        {
            await context.Attendances.AddAsync(Att);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendance()
        {
            return (await context.Attendances.ToListAsync());
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceByStudentId(int id)
        {
            //var StuData = await context.Attendances.FirstOrDefaultAsync(x => x.StudentId == id).ToListAsync();
            /*
             * by chat gpt
             * **/
            var attendanceData = await context.Attendances
            .Where(a => a.StudentId == id)
            .ToListAsync();
            return (attendanceData);
            
        }

        public async Task<Attendance> GetAttendancebyDateTime(DateTime DT)
        {
            var data = await context.Attendances.FirstOrDefaultAsync(x => x.AttendanceDate == DT);
            return data;
        }
    }
}
