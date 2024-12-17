using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class Vehical
{
    protected int Speed { get; set; }

	private double _fuel;

	public double Fuel
	{
		get { return _fuel; }
		set
		{ 
			if(value <= 50 + _fuel)
			{
				_fuel += value;
			}
		
		}
	}

}
