using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Dars.Services.DTOs;

public class StudentUpdateDto : StudentBaseDto
{
    public string Password { get; set; }
    public string UserName { get; set; }
    public Guid ID { get; set; }
}
