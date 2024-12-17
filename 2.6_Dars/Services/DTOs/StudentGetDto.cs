using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Dars.Services.DTOs;

public class StudentGetDto : StudentBaseDto
{
    public Guid ID { get; set; }
}
