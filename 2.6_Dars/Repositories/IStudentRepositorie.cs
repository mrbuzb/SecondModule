using _2._6_Dars.DataAcsess.Repos;

namespace _2._6_Dars.Repositories
{
    public interface IStudentRepositorie
    {
        Student WriteStudent(Student student);
        Student GetStudentByID(Guid id);
        void UpdateStudent(Student student);
        void DeleteStudent(Guid id);
        List<Student> GetAllStudents();
        void CheckEmailAndUserName(string email,string userName,string phone);
        void CheckUserName(string userName);
        void CheckEmail(string email);
        void CheckPhone(string email);
        void DeleteMessage(Student student, string message,string date);
    }
}