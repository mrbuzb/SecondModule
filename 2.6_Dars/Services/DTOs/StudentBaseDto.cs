using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Dars.Services.DTOs
{
    public class StudentBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public int NewMessages { get; set; } = 0;
        public int OldMessages { get; set; } = 0;
    }
}
