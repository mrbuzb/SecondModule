using _2._2dars.Api.Models;

namespace _2._2Dars.Services;

public interface ITeacherService
{
    public bool UpdateTeacher(Teacher teacher);
    public List<Teacher> GetAllTEachers();
    public bool DeleteTeacher(Guid id);

    public Teacher GetTeacherById(Guid id);
    public Teacher AddTeacher(Teacher teacher);
    public bool CheckLogin(string username, string password);
}
