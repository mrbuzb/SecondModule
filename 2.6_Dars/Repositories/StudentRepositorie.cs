using _2._6_Dars.DataAcsess.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._6_Dars.Repositories;

public class StudentRepositorie : IStudentRepositorie
{

    private string _studentFilePath = "../../../DataAcsess/Data/student.json";

    private List<Student> _students;

    public StudentRepositorie()
    {
        _students = new List<Student>();
        if (!File.Exists(_studentFilePath))
        {
            File.WriteAllText(_studentFilePath, "[]");
        }
        _students = GetStudents();
    }

    public void CheckEmailAndUserName(string email, string userName,string phone)
    {
        foreach (var student in _students)
        {
            if(student.Email == email ||student.UserName == userName || student.PhoneNumber ==phone )
            {
                throw new Exception("Unvaild User Exception");
            }
        }
    }

    public void DeleteStudent(Guid id)
    {
     var studentById = GetStudentByID(id);
        if (studentById is null)
        {
            throw new Exception("Student Unfinded");
        }
        _students.Remove(studentById);
        SaveData();
    }

    public List<Student> GetAllStudents()
    {
        return _students;
    }

    public Student GetStudentByID(Guid id)
    {
        foreach(var student in _students)
        {
            if(student.ID == id)
            {
                return student;
            }
        }

        throw new Exception("Not Finded User Exception");
    }

    public void UpdateStudent(Student student)
    {
        var studentById = GetStudentByID(student.ID);
        if (studentById is null)
        {
            throw new Exception("Not Updated Exception");
        }
        _students[_students.IndexOf(studentById)] = student;
        SaveData();
    }

    public Student WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student;
    }

    private void SaveData()
    {
        var convertedStudent = JsonSerializer.Serialize(_students);
        File.WriteAllText(_studentFilePath, convertedStudent);
    }

    private List<Student> GetStudents()
    {
        var readedJson = File.ReadAllText(_studentFilePath);
        var result =  JsonSerializer.Deserialize<List<Student>>(readedJson);
        return result;
    }

    public void CheckUserName(string userName)
    {
        foreach (var student in _students)
        {
            if (student.UserName == userName && userName.Length<5)
            {
                throw new Exception("Unvalid Exception");
            }
        }
    }

    public void CheckEmail(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email && !student.Email.EndsWith("@gmail.com"))
            {
                throw new Exception("Unvalid Email");
            }
        }
    }
    public void CheckPhone(string phone)
    {
        foreach (var student in _students)
        {
            if (student.PhoneNumber == phone)
            {
                throw new Exception("Unvalid Phone Number");
            }
        }
    }

    public void DeleteMessage(Student student ,string message, string date)
    {
        var result = false;
        foreach(var sms in student.Messages)
        {
            if(sms.Contains(message) && sms.Contains(date))
            {
                student.Messages.Remove(sms);
                UpdateStudent(student);
                result = true;
                break;
            }
        }
        if (result is false )
        {
            throw new Exception("Not Deleted Exception");
        }
    }
}
