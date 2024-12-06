using _2._2dars.Api.Models;
using System.Text.Json;

namespace _2._2dars.Api.Services;

public class StudentService
{
    private string studentFilePath;

    public StudentService()
    {
        studentFilePath = "../../../Data/Students.json";
        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
    }

    public bool CheckPassword(string username , string password)
    {
        var students = GetAllStudents();

        foreach (var student in students)
        {
            if(student.UserName == username && student.Password == password)
            {
                return true;
            }
        }
        return false;
    }



    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        var students = GetStudents();
        students.Add(student);
        SaveData(students);
        return student;
    }

    public Student GetById(Guid studentId)
    {
        var students = GetStudents();
        foreach (var student in students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public bool DeleteStudent(Guid studentId)
    {
        var students = GetStudents();
        var studentFromDb = GetById(studentId);
        if (studentFromDb is null)
        {
            return false;
        }
        foreach (var student in students)
        {
            if (student.Id == studentId)
            {
                students.Remove(student);
                break;
            }
        }
        SaveData(students);
        return true;
    }

    public bool UpdateStudent(Student student)
    {
        var students = GetStudents();
        var studentFromDb = GetById(student.Id);
        if (studentFromDb is null)
        {
            return false;
        }

        for (var i = 0;i<students.Count; i++)
        {
            if(students[i].Id == student.Id)
            {
                students[i] = student;
                break;
            }
        }

        SaveData(students);
        return true;
    }

    public List<Student> GetAllStudents()
    {
        return GetStudents();
    }

    private void SaveData(List<Student> students)
    {
        var studentsJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentFilePath, studentsJson);
    }

    private List<Student> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }
}