using System.ComponentModel.DataAnnotations;

namespace BooksStore.API.Dtos;

public record class BookDetailsDto(
    int Id,
    [Required][StringLength(50)] string Name,
    int GenreId
);

