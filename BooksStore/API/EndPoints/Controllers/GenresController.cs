using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BooksStore.API.Data;
using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly BookStoreContext context;

    public GenresController(BookStoreContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGenres()
    {
        var genres = await context.Genres
                              .Select(genre => new GenreDto(genre.Id, genre.Name))
                              .AsNoTracking()
                              .ToListAsync();

        return genres.Count > 0 ? Ok(genres) : NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var genre = await context.Genres.FindAsync(id);

        if (genre == null)
            return NoContent();

        return Ok(genre);
    }
}