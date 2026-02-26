using System.ComponentModel.DataAnnotations;

namespace BooksStore.API.Dtos;

public record class BookCreateDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(15)] string Genre
);