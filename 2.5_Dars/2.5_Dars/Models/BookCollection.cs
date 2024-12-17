using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class BookCollection
{

	private List<Book> _books;

    public BookCollection()
    {
        _books = new List<Book>();
    }


    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public List<Book> GetBookByAuthor(string author)
    {
        var booksByAuthor = new List<Book>();
        foreach (var book in _books)
        {
            if(book.Author == author)
            {
                booksByAuthor.Add(book);
            }
        }

        return booksByAuthor;
    }


}
