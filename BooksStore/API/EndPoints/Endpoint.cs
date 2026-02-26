using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

public static class EndPoint
{
    private const string getBook = "GetBook";
    
    private static readonly IPoint postPoint = new PostPoint(getBook);
    private static readonly IPoint getPoint = new GetPoint(getBook);
    private static readonly IPoint deletePoint = new DeletePoint();
    private static readonly IPoint putPoint = new PutPoint();

    private static readonly List<BookDto> books = [];

    public static void MapAll(this WebApplication app) 
    {
        getPoint.Point(app, books);
        putPoint.Point(app, books);
        postPoint.Point(app, books);
        deletePoint.Point(app, books);
    }
}