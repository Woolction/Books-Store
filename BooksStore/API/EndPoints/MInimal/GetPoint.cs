using Microsoft.EntityFrameworkCore;
using BooksStore.API.Models;
using BooksStore.API.Data;
using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class GetPoint : IPoint
{
    private readonly string getBook;
    public GetPoint(string getBook)
    {
        this.getBook = getBook;
    }

    public void Point(WebApplication app)
    {
        // GET all books
        app.MapGet("/books",
            async (BookStoreContext context) => await context.Books
            .Include(book => book.Genre)
            .Select(book => new BookSummaryDto(
                    book.Id, book.Name,
                    book.Genre!.Name))
            .AsNoTracking()
            .ToListAsync());

        // GET all books
        app.MapGet("/genres",
            async (BookStoreContext context) => await context.Genres
            .Select(genre => new GenreDto(genre.Id, genre.Name))
            .AsNoTracking().ToListAsync());

        // GET book by index
        app.MapGet("/books/{id}", async (int id, BookStoreContext context) =>
        {
            Book? book = await context.Books.FindAsync(id);

            if (book != null)
            {
                BookDetailsDto BookDetailsDto = new(
                    book.Id,
                    book.Name,
                    book.GenreId
                );

                return Results.Ok(BookDetailsDto);
            }

            return Results.NotFound();

        }).WithName(getBook);
    }
}