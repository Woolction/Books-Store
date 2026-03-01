namespace BooksStore.API.EndPoints;

public static class EndPoint
{
    private const string GetBookById = "GetBook";
    
    private static readonly IPoint postPoint = new PostPoint(GetBookById);
    private static readonly IPoint getPoint = new GetPoint(GetBookById);
    private static readonly IPoint deletePoint = new DeletePoint();
    private static readonly IPoint putPoint = new PutPoint();

    public static void MapAll(this WebApplication app) 
    {
        getPoint.Point(app);
        putPoint.Point(app);
        postPoint.Point(app);
        deletePoint.Point(app);
    }
}