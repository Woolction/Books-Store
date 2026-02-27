namespace BooksStore.API.Dtos;

public record class BookUpdateDto(
    string Name,
    int GenreId
    );