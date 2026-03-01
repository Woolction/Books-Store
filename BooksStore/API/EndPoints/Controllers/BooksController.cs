using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BooksStore.API.Models;
using BooksStore.API.Data;
using BooksStore.API.Dtos;

namespace BooksStore.API.EndPoints;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookStoreContext context;
    public BooksController(BookStoreContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await
            context.Books
               .Include(book => book.Genre)
               .Select(book => new BookSummaryDto(
                    book.Id, book.Name,
                    book.Genre!.Name))
                .AsNoTracking()
                .ToListAsync();

        return books.Count > 0 ? Ok(books) : NoContent();
    }

    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var books = await context.Books.Where(book => book.Id == id)
                                       .AsNoTracking().ToListAsync();
    
        return books.Count > 0 ? Ok(books) : NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostBook(BookDetailsDto newBook)
    {
        Genre? genre = await context.Genres.FindAsync(newBook.GenreId);
        
        if (genre == null)
        {
            return NotFound();
        }

        Book book = new()
        {
            Name = newBook.Name,
            GenreId = newBook.GenreId
        };

        context.Books.Add(book);

        await context.SaveChangesAsync();

        var bookDto = new BookSummaryDto(book.Id, book.Name, genre.Name);

        return CreatedAtAction("GetBookById", new { id = bookDto.Id }, bookDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBookById(int id, BookDetailsDto updatedBook)
    {
        Book? book = await context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        book.Name = updatedBook.Name;
        book.GenreId = updatedBook.GenreId;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookById(int id)
    {
        await context.Books.Where(book => book.Id == id).ExecuteDeleteAsync();

        return NoContent();
    }
}