using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models
{
    public class Matiz : Vehical
    {



        public void Refuel(int amount )
        {
             Fuel+=amount;
        }
        
        public void Drive(double dictance)
        {
            Console.WriteLine(dictance/Speed);
        }
    }
}
