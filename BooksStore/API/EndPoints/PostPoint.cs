using BooksStore.API.Models;
using BooksStore.API.Data;
using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class PostPoint : IPoint
{
    private readonly string getBook;
    public PostPoint(string getBook)
    {
        this.getBook = getBook;
    }

    public void Point(WebApplication app)
    {
        // CREATE book
        app.MapPost("/books", async (BookDetailsDto newBook, BookStoreContext context) =>
        {
            if (await context.Genres.FindAsync(newBook.GenreId) == null)
            {
                return Results.NotFound();
            }

            Book book = new()
            {
                Name = newBook.Name,
                GenreId = newBook.GenreId
            };

            context.Add(book);
            await context.SaveChangesAsync();

            BookDetailsDto createDto = new(
                book.Id,
                book.Name,
                book.GenreId
                );

            return Results.CreatedAtRoute(getBook, new { id = createDto.Id }, createDto);
        });

    }
}