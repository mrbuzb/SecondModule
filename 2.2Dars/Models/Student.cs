namespace _2._2dars.Api.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public Double Degree { get; set; }

    public string Gender { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public List<int> Results { get; set; } = new List<int>();
}