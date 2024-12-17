using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class User
{
	private string _firstName;

	public string FirstName
	{
        get { return _firstName; }
		set { _firstName = value; }
	}
	private string _lastName;

	public string LastName
    {
        get { return _lastName; }
		set { _lastName = value; }
	}


	private int _age;

	public int Age
	{
		get { return _age; }
		set { _age = value; }
	}

	private string _password;

	public string Password
	{
		get { return _password; }
		set { _password = value; }
	}

	private string _email;

	public string Email
	{
		get { return _email; }
		set { _email = value; }
	}

	private string _phoneNumber;

	public string PhoneNumber
	{
		get { return _phoneNumber; }
		set { _phoneNumber = value; }
	}





}
