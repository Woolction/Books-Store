using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class GetPoint : IPoint
{
    private readonly string getBook;
    public GetPoint(string getBook)
    {
        this.getBook = getBook;
    }

    public void Point(WebApplication app, List<BookDto> books)
    {
        // GET all books
        app.MapGet("/books", () => books);

        // GET book by index
        app.MapGet("/books/{id}", (int id) =>
        {
            BookDto? book = books.Find(books => books.Id == id);

            return book is null ? Results.NotFound() : Results.Ok(book);

        }).WithName(getBook);
    }
}