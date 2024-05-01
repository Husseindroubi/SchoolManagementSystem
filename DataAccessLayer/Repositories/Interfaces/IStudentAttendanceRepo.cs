using ModelsLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IStudentAttendanceRepo : IRepository<StudentAttendance>
    {
        void Update(StudentAttendance StudentAttendance);
    }
}