using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        for (int index = 0; index < this.books.Count; index++)
        {
            yield return this.books[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
