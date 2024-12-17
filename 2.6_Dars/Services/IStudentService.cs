using _2._6_Dars.DataAcsess.Repos;
using _2._6_Dars.Services.DTOs;

namespace _2._6_Dars.Services
{
    public interface IStudentService
    {
        StudentGetDto CreateStudent(StudentCreateDto student);
        StudentUpdateDto GetStudentByPhoneForMessage(string phone);
        void UpdateStudent(StudentUpdateDto student);
        void DeleteStudent(Guid id);
        List<StudentGetDto> GetAllStudents();
        Student CheckLogin(string username, string password);

        void DeleteMessage(Student student , string message,string date);
    }
}                   