using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class BankAccaunt
{
	private readonly string  _accauntNumber;


	public string AccountNumber
	{
		get { return  _accauntNumber; }
	}

	private  double _balance = 0;

	public   double Balance
	{
		get { return _balance ; }
	}

	public void Deposit (double balance)
	{
            _balance  += balance;
	}



}
