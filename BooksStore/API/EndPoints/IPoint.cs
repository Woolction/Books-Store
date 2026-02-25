using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public interface IPoint
{
    void Point(WebApplication app, List<BookDto> books);
}