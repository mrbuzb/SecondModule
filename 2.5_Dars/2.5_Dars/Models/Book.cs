using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class Book
{
    private string _author;

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }
    private string _title;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

}
