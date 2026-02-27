using BooksStore.API.Data;
using BooksStore.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.API.EndPoints;

public class DeletePoint : IPoint
{
    public void Point(WebApplication app)
    {
        //DELETE book
        app.MapDelete("/books/{id}", async (int id, BookStoreContext context) =>
        {
            await context.Books.Where(books => books.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}