using _2._2Dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2Dars.Services;

public class TestService : ITestService
{
    private string testFilePath;


    public TestService()
    {
        testFilePath =  "../../../Data/Test.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
    }



    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();

        var tests = GetAllTests();

        tests.Add(test);

        SaveInformation(tests);
        return test;
    }


    public Test GetTestById(Guid id)
    {
        var tests = GetAllTests();

        foreach (var test in tests)
        {
            if (test.Id == id)
            {
                return test;
            }
        }
        return null;
    }


    public bool UpdateTest(Test test)
    {

        var findedTest = GetTestById(test.Id);

        if(findedTest is null)
        {
            return false;
        }

        var tests = GetAllTests();

        for (var i = 0; i < tests.Count; i++)
        {
            if(tests[i].Id == test.Id)
            {
                tests[i] = test;
            }
        }
       SaveInformation(tests);

        return true;
    }

    public bool DeleteTest(Guid id)
    {
        var test = GetTestById(id);

        if (test is null)
        {
            return false ;
        }

        var tests =GetAllTests();

        foreach(var testt in tests)
        {
            if(testt.Id == id)
            {
                tests.Remove(testt);
                break;
            }
        }
        SaveInformation(tests);
        return true;
    }

    public List<Test> AllTests()
    {
        return GetAllTests();
    }










    private void SaveInformation(List<Test> tests)
    {

        var testJson = JsonSerializer.Serialize(tests);

        File.WriteAllText(testFilePath, testJson);

    }

    private List<Test> GetAllTests()
    {
        var file = File.ReadAllText(testFilePath);

        var testsFromDb = JsonSerializer.Deserialize<List<Test>>(file);

        return testsFromDb;
    }










}
