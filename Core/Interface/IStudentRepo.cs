namespace Attendance_Project.Core.Interface
{
    public interface IStudentRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllStudend();
        Task<T> GetStudentByID(int id);
        Task<bool> AddStudent(T entity);
        Task<bool> UpdateStudent(T entity);
        Task<bool> DeleteStudent(int id);
    }
}
