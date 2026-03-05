namespace BooksStore.API.Services;

public class TimeGetter : ITimeService
{
    public string GetTime()
    {
        return DateTime.Now.ToLongTimeString();
    }
}