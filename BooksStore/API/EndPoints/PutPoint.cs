using BooksStore.API.Data;
using BooksStore.API.Dtos;
using BooksStore.API.Models;

namespace BooksStore.API.EndPoints;

public class PutPoint : IPoint
{
    public void Point(WebApplication app)
    {
        //UPDATE book
        app.MapPut("/books/{id}", async (int id, BookUpdateDto updatedDto, BookStoreContext context) =>
        {
            Book? book = await context.Books.FindAsync(id);

            if (book == null)
                return Results.NotFound();

            book.Id = id;
            book.Name = updatedDto.Name;
            book.GenreId = updatedDto.GenreId;

            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}