using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Attendance_Project.data;
using Attendance_Project.Models;
using Attendance_Project.Core.Interface;

namespace Attendance_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceContoller : ControllerBase
    {
        //private readonly AttendanceProContext context;
        private readonly IAttendanceRepo<Attendance> IAttRepo;
        public AttendanceContoller(IAttendanceRepo<Attendance> _IAttRepo)
        {
            IAttRepo = _IAttRepo;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAttendanceRecord()
        //{
        //    var data = await context.Attendances.ToListAsync();
        //    return Ok(data);
        //}
        [HttpGet]
        public async Task<IActionResult> getAllAttendance()
        {
            var data =await IAttRepo.GetAllAttendance();
            return Ok(data);
        }
        [HttpGet("byDateTime/{DT}")]
        public async Task<IActionResult> GetAttByDateTime(DateTime DT)
        {
            var data = await IAttRepo.GetAttendancebyDateTime(DT);
            return Ok(data);
        }
        [HttpGet("byStudentId/{id}")]
        public async Task<IActionResult> GetAllAttByStudentId(int id)
        {
            var data = IAttRepo.GetAllAttendanceByStudentId(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddAtt(Attendance Att)
        {
            var data = IAttRepo.AddAttendance(Att);
            return Ok(data);
        }
    }
}
