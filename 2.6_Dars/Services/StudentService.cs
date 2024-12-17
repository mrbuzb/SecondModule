using _2._6_Dars.DataAcsess.Repos;
using _2._6_Dars.Repositories;
using _2._6_Dars.Services.DTOs;

namespace _2._6_Dars.Services;

public class StudentService : IStudentService
{

    private readonly IStudentRepositorie _studentRepositorie;

    public StudentService()
    {
        _studentRepositorie = new StudentRepositorie();
    }

    public Student CheckLogin(string username, string password)
    {
        var students = _studentRepositorie.GetAllStudents();
        foreach (var student in students)
        {
            if (student.UserName == username && student.Password == password)
            {
                return student;
            }
        }
        return null;
    }

    public StudentGetDto CreateStudent(StudentCreateDto student)
    {
         _studentRepositorie.CheckEmailAndUserName(student.Email, student.UserName, student.PhoneNumber);
        if (student.Password.Length < 8 || !student.Email.EndsWith("@gmail.com"))
        {
            throw new Exception("Unvalid User Exception");
        }
        var studentDto = ConvertStudent(student);
        studentDto.ID = Guid.NewGuid();
        _studentRepositorie.WriteStudent(studentDto);
        var studentGetDto = ConvertStudent(studentDto);
        return studentGetDto;
    }

    public void DeleteMessage(Student student, string message, string date)
    {
        _studentRepositorie.DeleteMessage(student, message, date);
    }

    public void DeleteStudent(Guid id)
    {
        _studentRepositorie.DeleteStudent(id);
    }

    public List<StudentGetDto> GetAllStudents()
    {
        var studentGetDtos = new List<StudentGetDto>();
        var students = _studentRepositorie.GetAllStudents();
        foreach (var student in students)
        {
            studentGetDtos.Add(ConvertStudent(student));
        }
        return studentGetDtos;
    }

    public StudentUpdateDto GetStudentByPhoneForMessage(string phone)
    {
        var students = _studentRepositorie.GetAllStudents();
        var result = new StudentUpdateDto();
        foreach (var student in students)
        {
            if (student.PhoneNumber == phone)
            {
                result = ConvertStudentForMessage(student);
            }
        }

        return result;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        _studentRepositorie.UpdateStudent(ConvertStudent(student));
    }


    private StudentGetDto ConvertStudent(Student student)
    {
        var studentgetdto = new StudentGetDto()
        {
            ID = Guid.NewGuid(),
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            PhoneNumber = student.PhoneNumber,
            Email = student.Email,
            Messages = student.Messages,
            NewMessages = student.NewMessages,
            OldMessages = student.OldMessages,
        };
        return studentgetdto;
    }

    private Student ConvertStudent(StudentCreateDto studentGetDto)
    {
        var result = new Student()
        {
            FirstName = studentGetDto.FirstName,
            LastName = studentGetDto.LastName,
            Age = studentGetDto.Age,
            PhoneNumber = studentGetDto.PhoneNumber,
            Email = studentGetDto.Email,
            Password = studentGetDto.Password,
            UserName = studentGetDto.UserName,
            Messages = studentGetDto.Messages,
            NewMessages = studentGetDto.NewMessages,
            OldMessages = studentGetDto.OldMessages,







        };
        return result;
    }


    private Student ConvertStudent(StudentUpdateDto studentUpdateDto)
    {
        return new Student()
        {
            ID = studentUpdateDto.ID,
            FirstName = studentUpdateDto.FirstName,
            LastName = studentUpdateDto.LastName,
            Age = studentUpdateDto.Age,
            PhoneNumber = studentUpdateDto.PhoneNumber,
            Email = studentUpdateDto.Email,
            Password = studentUpdateDto.Password,
            UserName = studentUpdateDto.UserName,
            Messages = studentUpdateDto.Messages,
            NewMessages = studentUpdateDto.NewMessages,
            OldMessages = studentUpdateDto.OldMessages,
        };
    }

    private StudentUpdateDto ConvertStudentForMessage(Student studentUpdateDto)
    {
        var result = new StudentUpdateDto()
        {
            ID = studentUpdateDto.ID,
            FirstName = studentUpdateDto.FirstName,
            LastName = studentUpdateDto.LastName,
            Age = studentUpdateDto.Age,
            PhoneNumber = studentUpdateDto.PhoneNumber,
            Email = studentUpdateDto.Email,
            Password = studentUpdateDto.Password,
            UserName = studentUpdateDto.UserName,
            Messages = studentUpdateDto.Messages,
            NewMessages = studentUpdateDto.NewMessages,
            OldMessages = studentUpdateDto.OldMessages,
        };
        return result;
    }



}
