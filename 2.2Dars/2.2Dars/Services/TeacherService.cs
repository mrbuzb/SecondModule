using _2._2dars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2Dars.Services;

public class TeacherService
{

    private string teacherFilePath;

    public TeacherService()
    {
        teacherFilePath = "../../../Data/Teacher.json";

        if(File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
    }

    private void SaveData(List<Teacher> teachers)
    {
        var teacherJson = JsonSerializer.Serialize(teachers);
        File.WriteAllText(teacherFilePath, teacherJson);
    }

    private List<Teacher> GetTeachers()
    {
        var teacherList = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teacherList);
        return teachers;
    }

    public bool CheckLogin(string username, string password)
    {
        var teachers= GetAllTEachers();
        foreach(var teacher in teachers)
        {
            if(teacher.Username == username && teacher.Password == password)
            {
                return true;
            }
        }

        return false;
    }


    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        var teachersList = GetTeachers();
        teachersList.Add(teacher);
        SaveData(teachersList);
        return teacher;
    }

    public Teacher GetTeacherById(Guid id)
    {
        var teachers = GetTeachers();
        foreach(var teacher in teachers)
        {
            if(teacher.Id == id)
            {
                return teacher;
            }
        }
        return null;
    }

    public bool DeleteTeacher(Guid id)
    {
        var res = GetTeacherById(id);

        if(res is null)
        {
            return false;
        }
        var teachers = GetTeachers();
        foreach(var teacher in teachers)
        {
            if( teacher.Id == id)
            {
                teachers.Remove(teacher);
                break;
            }
        }
        SaveData(teachers);

        return true;
    }

    public List<Teacher> GetAllTEachers()
    {
        return GetTeachers();
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var res = GetTeacherById(teacher.Id);
        if(res is null)
        {
            return false;
        }

        var teachers = GetTeachers();
        for(var i = 0;i< teachers.Count;i++)
        {
            if (teachers[i].Id == teacher.Id)
            {
                teachers[i] = teacher;
            }
        }
        SaveData(teachers);
        return true;
    }




}
