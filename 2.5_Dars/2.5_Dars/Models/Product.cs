using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class Product
{
	private double _price;

	public double Price
	{
		get { return _price; }
		set { _price = value; }
	}

	private string _stock;

	public string Stock
	{
		get { return _stock; }
		set { _stock = value; }
	}



}
