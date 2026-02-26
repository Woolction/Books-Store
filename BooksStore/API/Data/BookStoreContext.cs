using Microsoft.EntityFrameworkCore;
using BooksStore.API.Models;

namespace BooksStore.API.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) {}
    public DbSet<Book> Books => Set<Book>(); 
    public DbSet<Genre> Genres => Set<Genre>();
}