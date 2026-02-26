using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class PostPoint : IPoint
{
    private readonly string getBook;
    public PostPoint(string getBook)
    {
        this.getBook = getBook;
    }
    
    public void Point(WebApplication app, List<BookDto> books)
    {
        // CREATE book
        app.MapPost("/books", (BookCreateDto newBook) =>
        {
            BookDto book = new(books.Count + 1, newBook.Name, newBook.Genre);

            books.Add(book);

            return Results.CreatedAtRoute(getBook, new { id = book.Id }, book);
        });

    }
}