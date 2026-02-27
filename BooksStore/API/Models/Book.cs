namespace BooksStore.API.Models;

public class Book
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public Genre? Genre { get; set; }
    public int GenreId { get; set; }
}