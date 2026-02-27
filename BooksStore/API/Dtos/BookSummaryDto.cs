using System.ComponentModel.DataAnnotations;

namespace BooksStore.API.Dtos;

public record class BookSummaryDto(
    int Id,
    [Required][StringLength(50)] string Name,
    [Required] string GenreName
);