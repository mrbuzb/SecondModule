using _2._2Dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2Dars.Services;

public interface ITestService
{
    public Test AddTest(Test test);
    public Test GetTestById(Guid id);
    public bool UpdateTest(Test test);
    public bool DeleteTest(Guid id);
    public List<Test> AllTests();
}
