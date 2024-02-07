namespace Attendance_Project.Core.Interface
{
    public interface IAttendanceRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAttendance();
        Task<T> GetAttendancebyDateTime(DateTime DT);
        Task<IEnumerable<T>> GetAllAttendanceByStudentId(int id);
        Task<bool> AddAttendance(T entity);
    }
}
