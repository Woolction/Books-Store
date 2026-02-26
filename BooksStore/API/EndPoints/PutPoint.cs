using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public class PutPoint : IPoint
{
    public void Point(WebApplication app, List<BookDto> books)
    {
        //UPDATE book
        app.MapPut("/books/{id}", (int id, BookUpdateDto updatedDto) =>
        {
            if (id < 0)
            {
                return Results.NotFound();
            }

            books[id] = new(id, updatedDto.Name, updatedDto.Genre);

            return Results.NoContent();
        });
    }
}