using BooksStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.API.Data;

public static class DbExtenstion
{
    public static void MigrateDb(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        BookStoreContext books = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
        books.Database.Migrate();
    }

    public static void AddBookStoreDb(this WebApplicationBuilder builder)
    {
        string? connection = builder.Configuration.GetConnectionString("BookStore");

        builder.Services.AddSqlite<BookStoreContext>(
            connection,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.AddRange(
                        new Genre() { Name = "History" },
                        new Genre() { Name = "Detective" },
                        new Genre() { Name = "Romance" },
                        new Genre() { Name = "Fighting" },
                        new Genre() { Name = "Fanastic" }
                    );

                    context.SaveChanges();
                }
            }));
    }
}