using _2._6_Dars.Services;
using _2._6_Dars.Services.DTOs;

namespace _2._6_Dars
{

    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }

        public static void FrontEnd()
        {
            IStudentService studentService = new StudentService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Sign Up");//login
                Console.WriteLine("2.Sign In");//Registratsiya
                Console.Write("Choose > > ");
                var option = Console.ReadLine();
                Console.Clear();
                if (option == "1")
                {
                    var student = new StudentCreateDto();
                    Console.Write("Enter Your First Name : ");
                    student.FirstName = Console.ReadLine();
                    Console.Write("Enter Your Last Name : ");
                    student.LastName = Console.ReadLine();
                    Console.Write("Enter Your Age : ");
                    student.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Your Phone Number : ");
                    student.PhoneNumber = Console.ReadLine();
                    Console.Write("Enter Your Email : ");
                    student.Email = Console.ReadLine();
                    Console.Write("Enter Your UserName : ");
                    student.UserName = Console.ReadLine();
                    Console.Write("Enter Your Password : ");
                    student.Password = Console.ReadLine();

                    var result = studentService.CreateStudent(student);
                    if (result is null)
                    {
                        Console.WriteLine("Something Went Wrong!");
                    }
                    else
                    {
                        Console.WriteLine("Login Saved Succesfully ! ! !");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == "2")
                {
                    Console.Write("Username : ");
                    var username = Console.ReadLine();
                    Console.Write("Password : ");
                    var password = Console.ReadLine();
                    var result = studentService.CheckLogin(username, password);
                    if (result is null)
                    {
                        Console.WriteLine("Wrong Password ! ! !");
                    }
                    else
                    {
                        while (true)
                        {
                            Console.Clear();
                            if (result.NewMessages > result.OldMessages)
                            {
                                Console.WriteLine($"\t\tYou Have {result.NewMessages - result.OldMessages} New Messages\n\n ");
                            }
                            Console.WriteLine("0. < - Back");
                            Console.WriteLine("1.Send Message");
                            Console.WriteLine("2.Read My Messages");
                            Console.WriteLine("3.Dlete Message");
                            Console.Write("Choose > >");
                            var choose = Console.ReadLine();
                            if (choose == "1")
                            {
                                Console.Write("Enter Reciver Phone Number : ");
                                var reciverPhone =Console.ReadLine();
                                var getReciver = studentService.GetStudentByPhoneForMessage(reciverPhone);
                                if (getReciver is null || getReciver.ID == result.ID)
                                {
                                    Console.WriteLine("Wrong ID!");
                                }
                                else
                                {
                                    Console.Write("Enter Your Message : ");
                                    var message = Console.ReadLine();
                                    message = "Message : "+message;
                                    message += $"\nFrom : {result.PhoneNumber}";
                                    message += $"\nDate Time : {DateTime.Now}";
                                    getReciver.Messages.Add(message);
                                    studentService.UpdateStudent(getReciver);
                                    getReciver.NewMessages = getReciver.Messages.Count;
                                    studentService.UpdateStudent(getReciver);

                                    Console.WriteLine("Message Sent Succesfully ! ! !");
                                }
                            }
                            else if (choose == "2")
                            {
                                Console.Clear();
                                var getReciver = studentService.GetStudentByPhoneForMessage(result.PhoneNumber);
                                foreach (var sms in getReciver.Messages)
                                {
                                    Console.WriteLine(sms);
                                    Console.WriteLine();
                                }
                                getReciver.NewMessages = getReciver.Messages.Count;
                                getReciver.OldMessages = getReciver.Messages.Count;
                                studentService.UpdateStudent(getReciver);
                                result.NewMessages = getReciver.Messages.Count;
                                result.OldMessages = getReciver.Messages.Count;

                                Console.ReadKey();
                                continue;
                            }
                            else if(choose == "3")
                            {
                                Console.Clear();
                                Console.Write("Enter Deleted Message : ");
                                var delMessage = Console.ReadLine();
                                Console.Write("Enter Sent Time : ");
                                var time = Console.ReadLine();
                                studentService.DeleteMessage(result, delMessage, time);
                                
                                    Console.WriteLine("Deleted ! ! !");
                            }
                            else if (choose == "0")
                            {
                                break;
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else if (option == "3")
                {

                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
