using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class DeletePoint : IPoint
{
    public void Point(WebApplication app, List<BookDto> books)
    {
        //DELETE book
        app.MapDelete("/books/{id}", (int id) =>
        {
            books.RemoveAll(games => games.Id == id);

            return Results.NoContent();
        });
    }
}