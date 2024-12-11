using _2._2dars.Api.Models;
using _2._2dars.Api.Services;
using _2._2Dars.Models;
using _2._2Dars.Services;

namespace _2._2Dars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FirstMenu();
        }

        public static void FirstMenu()
        {

            IDirectorService directorService = new DirectorService();
            ITeacherService teacherService = new TeacherService();
            IStudentService studentSevice = new StudentService();

            while (true)
            {
                Console.Clear();

                Console.Write("Enter Username : ");
                var userName = Console.ReadLine();
                Console.Write("Enter Password  : ");
                var password = Console.ReadLine();


                if (directorService.CheckDitrectorPassword(userName, password) is true)
                {
                    DirectorMenu();
                }
                else if (teacherService.CheckLogin(userName, password) is true)
                {
                    TeacherMenu();
                }
                else if (studentSevice.CheckPassword(userName, password))
                {
                    StudentMenu(userName);
                }
                else
                {
                    Console.WriteLine("Wrong UserName Or Password");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public static void DirectorMenu()
        {
            ITeacherService teacherService = new TeacherService();
            IDirectorService directorService = new DirectorService();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1.Add Teacher");
                Console.WriteLine("2.Delete Teacher");
                Console.WriteLine("3.Get Teacher By Id");
                Console.WriteLine("4.Update Teacher");
                Console.WriteLine("5.Get All Teachers");
                Console.WriteLine("6.Update Login ");
                Console.WriteLine("7.Back <");
                Console.Write("Choose > > ");
                var option = Console.ReadLine();
                Console.Clear();
                //public string FirstName { get; set; }
                //public string LastName { get; set; }
                //public int Age { get; set; }
                //public string Subject { get; set; }
                //public int Likes { get; set; }
                //public int DisLikes { get; set; }
                //public string Gender { get; set; }

                if (option == "1")
                {
                    var newTeacher = new Teacher();
                    Console.Write("Enter Teachers FirstName :");
                    newTeacher.FirstName = Console.ReadLine();
                    Console.Write("Enter Teachers LastName :");
                    newTeacher.LastName = Console.ReadLine();
                    Console.Write("Enter Teachers Age :");
                    newTeacher.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers Subject :");
                    newTeacher.Subject = Console.ReadLine();
                    Console.Write("Enter Teachers Likes :");
                    newTeacher.Likes = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers DissLikes :");
                    newTeacher.DisLikes = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers Gender :");
                    newTeacher.Gender = Console.ReadLine();
                    Console.Write("Enter Teacher's Username : ");
                    newTeacher.Username = Console.ReadLine();
                    Console.Write("Enter Teacher's Password : ");
                    newTeacher.Password = Console.ReadLine();
                    teacherService.AddTeacher(newTeacher);
                    Console.WriteLine("Teacher Added!");
                }

                else if (option == "2")
                {
                    Console.Write("Enter Deleted Teacher's Id : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var res = teacherService.DeleteTeacher(id);
                    if (res is true)
                    {
                        Console.WriteLine("Deleted Succesfully !");
                    }
                    else
                    {
                        Console.WriteLine("Wrong ID !");
                    }
                }

                else if (option == "3")
                {

                    Console.Write("Enter Teachers Id : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var res = teacherService.GetTeacherById(id);

                    if (res is null)
                    {
                        Console.WriteLine("Error Ocured !");
                    }
                    else
                    {
                        Console.WriteLine($"Teacher's Id : {res.Id}");
                        Console.WriteLine($"Teacher's First Name : {res.FirstName}");
                        Console.WriteLine($"Teacher's Last Name : {res.LastName}");
                        Console.WriteLine($"Teacher's Age : {res.Age}");
                        Console.WriteLine($"Teacher's Likes : {res.Likes}");
                        Console.WriteLine($"Teacher's Dislikes : {res.DisLikes}");
                        Console.WriteLine($"Teacher's UserName : {res.Username}");
                        Console.WriteLine($"Teacher's Password : {res.Password}");
                    }
                }

                else if (option == "4")
                {

                    var newTeacher = new Teacher();
                    Console.Write("Enter Updated Teacher's Id :  ");
                    newTeacher.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers FirstName :");
                    newTeacher.FirstName = Console.ReadLine();
                    Console.Write("Enter Teachers LastName :");
                    newTeacher.LastName = Console.ReadLine();
                    Console.Write("Enter Teachers Age :");
                    newTeacher.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers Subject :");
                    newTeacher.Subject = Console.ReadLine();
                    Console.Write("Enter Teachers Likes :");
                    newTeacher.Likes = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers DissLikes :");
                    newTeacher.DisLikes = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teachers Gender :");
                    newTeacher.Gender = Console.ReadLine();
                    Console.Write("Enter Teacher's Username : ");
                    newTeacher.Username = Console.ReadLine();
                    Console.Write("Enter Teacher's Password : ");
                    newTeacher.Password = Console.ReadLine();


                    var res = teacherService.UpdateTeacher(newTeacher);

                    if (res is true)
                    {
                        Console.WriteLine("Updated Succesfully !");
                    }
                    else
                    {
                        Console.WriteLine("Error Occured . Not Updated!");
                    }
                }

                else if (option == "5")
                {
                    var allTeachers = teacherService.GetAllTEachers();

                    foreach (var res in allTeachers)
                    {
                        Console.WriteLine($"Teacher's Id : {res.Id}");
                        Console.WriteLine($"Teacher's First Name : {res.FirstName}");
                        Console.WriteLine($"Teacher's Last Name : {res.LastName}");
                        Console.WriteLine($"Teacher's Age : {res.Age}");
                        Console.WriteLine($"Teacher's Likes : {res.Likes}");
                        Console.WriteLine($"Teacher's Dislikes : {res.DisLikes}");
                        Console.WriteLine($"Teacher's UserName : {res.Username}");
                        Console.WriteLine($"Teacher's Password : {res.Password}");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                else if (option == "6")
                {
                    directorService.ChangeLogin();
                }

                else if (option == "7")
                {
                    break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void TeacherMenu()
        {
            Console.Clear();
            IStudentService studentService = new StudentService();
            ITeacherService teacherService = new TeacherService();
            ITestService testService = new TestService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Delete Student");
                Console.WriteLine("3.Get Student By ID ");
                Console.WriteLine("4.Delete Student");
                Console.WriteLine("5.Get All Students ");
                Console.WriteLine("6.Add Test ");
                Console.WriteLine("7.Update Test ");
                Console.WriteLine("8.Delete Test ");
                Console.WriteLine("9.Get Test By ID");
                Console.WriteLine("10.Get All Tests ");
                Console.WriteLine("11.Back <");
                Console.Write("Choose  > >");
                var option = Console.ReadLine();
                Console.Clear();


                if (option == "1")
                {
                    //public string FirstName { get; set; }
                    //public string LastName { get; set; }
                    //public int Age { get; set; }
                    //public string Degree { get; set; }
                    //public string Gender { get; set; }
                    var newStudent = new Student();

                    Console.Write("Enter Student's First Name : ");
                    newStudent.FirstName = Console.ReadLine();
                    Console.Write("Enter Student's Last Name : ");
                    newStudent.LastName = Console.ReadLine();
                    Console.Write("Enter Student's Age : ");
                    newStudent.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student's Degree : ");
                    newStudent.Degree = Double.Parse(Console.ReadLine());
                    Console.Write("Enter Student's Gender : ");
                    newStudent.Gender = Console.ReadLine();
                    Console.Write("Enter Student's UserName : ");
                    newStudent.UserName = Console.ReadLine();
                    Console.Write("Enter Student's Password : ");
                    newStudent.Password = Console.ReadLine();

                    Console.WriteLine("Student Added!");

                    studentService.AddStudent(newStudent);
                }

                else if (option == "2")
                {
                    Console.Write("Enter Deleted Student's Id ");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = studentService.DeleteStudent(id);

                    if (result is true)
                    {
                        Console.WriteLine("Deleted Succefully ");
                    }
                    else
                    {
                        Console.WriteLine("Not Deleted !");
                    }
                }

                else if (option == "3")
                {
                    Console.Write("Enter Student's ID : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var result = studentService.GetById(id);

                    if (result is null)
                    {
                        Console.WriteLine("Wrong ID");
                    }
                    else
                    {
                        Console.WriteLine($"Student''s Id : {result.Id}");
                        Console.WriteLine($"Student''s FirstName : {result.FirstName}");
                        Console.WriteLine($"Student''s Last Name : {result.LastName}");
                        Console.WriteLine($"Student''s Age : {result.Age}");
                        Console.WriteLine($"Student''s Degree : {result.Degree}");
                        Console.WriteLine($"Student''s Gender : {result.Gender}");
                        Console.WriteLine($"Student''s UserName : {result.UserName}");
                        Console.WriteLine($"Student''s Password : {result.Password}");
                        Console.Write("Student Results : ");
                        foreach (var resultt in result.Results)
                        {
                            Console.Write($"{resultt} ");
                        }
                    }

                }
                else if (option == "4")
                {
                    Console.Write("Enter Deleted Student's Id : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var result = studentService.DeleteStudent(id);

                    if (result is false)
                    {
                        Console.WriteLine("Wrong ID ");
                    }
                    else
                    {
                        Console.WriteLine("Deleted Succesfully");
                    }

                }

                else if (option == "5")
                {
                    var students = studentService.GetAllStudents();

                    foreach (var result in students)
                    {
                        Console.WriteLine($"Student''s Id : {result.Id}");
                        Console.WriteLine($"Student''s FirstName : {result.FirstName}");
                        Console.WriteLine($"Student''s Last Name : {result.LastName}");
                        Console.WriteLine($"Student''s Age : {result.Age}");
                        Console.WriteLine($"Student''s Degree : {result.Degree}");
                        Console.WriteLine($"Student''s Gender : {result.Gender}");
                        Console.WriteLine($"Student''s UserName : {result.UserName}");
                        Console.WriteLine($"Student''s Password : {result.Password}");
                        Console.Write("Student Results : ");
                        foreach (var resultt in result.Results)
                        {
                            Console.Write($"{resultt} ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                else if (option == "6")
                {
                    var test = new Test();

                    Console.Write("Enter Test Question : ");
                    test.QuestionText = Console.ReadLine();
                    Console.Write("Enter A  Variant  : ");
                    test.AVariant = Console.ReadLine();
                    Console.Write("Enter B  Variant  : ");
                    test.BVariant = Console.ReadLine();
                    Console.Write("Enter C  Variant  : ");
                    test.CVariant = Console.ReadLine();
                    Console.Write("Answer : ");
                    test.Answer = Console.ReadLine();

                    Console.WriteLine("Test Added");
                    testService.AddTest(test);



                }

                else if (option == "7")
                {
                    var test = new Test();

                    Console.Write("Enter Updated Test ID : ");
                    test.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter Test Question : ");
                    test.QuestionText = Console.ReadLine();
                    Console.Write("Enter A  Variant  : ");
                    test.AVariant = Console.ReadLine();
                    Console.Write("Enter B  Variant  : ");
                    test.BVariant = Console.ReadLine();
                    Console.Write("Enter C  Variant  : ");
                    test.CVariant = Console.ReadLine();
                    Console.Write("Answer : ");
                    test.Answer = Console.ReadLine();

                    var result = testService.UpdateTest(test);

                    if (result == false)
                    {
                        Console.WriteLine("Not Updated ");
                    }
                    else
                    {
                        Console.WriteLine("Updated");
                    }

                }

                else if (option == "8")
                {
                    Console.Write("Enter Deleted Test ID : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var result = testService.DeleteTest(id);

                    if (result == false)
                    {
                        Console.WriteLine("Not Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Deleted Succefully ! ");
                    }

                }
                else if (option == "9")
                {
                    Console.Write("Enter Test's ID : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var result = testService.GetTestById(id);

                    if (result is null)
                    {
                        Console.WriteLine("Wrong ID ");
                    }
                    else
                    {
                        Console.WriteLine(result.Id);
                        Console.WriteLine(result.QuestionText);
                        Console.WriteLine(result.AVariant);
                        Console.WriteLine(result.BVariant);
                        Console.WriteLine(result.CVariant);
                        Console.WriteLine(result.Answer);
                    }

                }
                else if (option == "10")
                {
                    var results = testService.AllTests();
                    foreach (var result in results)
                    {
                        Console.WriteLine(result.Id);
                        Console.WriteLine(result.QuestionText);
                        Console.WriteLine(result.AVariant);
                        Console.WriteLine(result.BVariant);
                        Console.WriteLine(result.CVariant);
                        Console.WriteLine(result.Answer);
                    }
                }
                else if (option == "11")
                {
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void StudentMenu(string userName)
        {
            IStudentService studentService = new StudentService();
            ITestService testService = new TestService();
            while (true)
            {
                var allStudents = studentService.GetAllStudents();
                Student student = new Student();
                foreach (var studentt in allStudents)
                {
                    if (studentt.UserName == userName)
                    {
                        student = studentt;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("1.Get Test By ID ");
                Console.WriteLine("2.Get All Tests");
                Console.WriteLine("3.My Answers");
                Console.WriteLine("4.Back <");
                Console.Write("Choose > >");
                var option = Console.ReadLine();
                Console.Clear();
                if (option == "1")
                {
                    Console.Write("Enter Tests ID : ");
                    var id = Guid.Parse(Console.ReadLine());

                    var result = testService.GetTestById(id);

                    if (result is null)
                    {
                        Console.WriteLine("Wrong ID ");
                    }
                    else
                    {
                        //public Guid Id { get; set; }
                        //public string QuestionText { get; set; }
                        //public string AVariant { get; set; }
                        //public string BVariant { get; set; }
                        //public string CVariant { get; set; }
                        //public string Answer { get; set; }


                        Console.WriteLine($"Test's ID : {result.Id} ");
                        Console.WriteLine($"Test's Question : {result.QuestionText} ");
                        Console.WriteLine($"Variant A : {result.AVariant} ");
                        Console.WriteLine($"Variant B : {result.BVariant} ");
                        Console.WriteLine($"Variant C : {result.CVariant} ");

                        Console.Write("Enter Answer : ");
                        var stuAnswer = Console.ReadLine();
                        if (stuAnswer == result.Answer)
                        {
                            student.Results.Add(1);
                            studentService.UpdateStudent(student);
                        }
                        else
                        {
                            student.Results.Add(0);
                            studentService.UpdateStudent(student);
                        }
                    }
                }
                else if (option == "2")
                {
                    var allTests = testService.AllTests();

                    foreach (var result in allTests)
                    {
                        Console.WriteLine($"Test's ID : {result.Id} ");
                        Console.WriteLine($"Test's Question : {result.QuestionText} ");
                        Console.WriteLine($"Variant A : {result.AVariant} ");
                        Console.WriteLine($"Variant B : {result.BVariant} ");
                        Console.WriteLine($"Variant C : {result.CVariant} ");

                        Console.Write("Enter Answer : ");
                        var stuAnswer = Console.ReadLine();
                        if (stuAnswer == result.Answer)
                        {
                            student.Results.Add(1);
                            studentService.UpdateStudent(student);
                        }
                        else
                        {
                            student.Results.Add(0);
                            studentService.UpdateStudent(student);
                        }
                    }
                }
                else if (option == "3")
                {
                    foreach (var result in student.Results)
                    {
                        Console.Write($"{result} ");
                    }
                }
                else if (option == "4")
                {
                    break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
