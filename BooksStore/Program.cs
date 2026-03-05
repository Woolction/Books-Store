using BooksStore.API.Middleware;
using BooksStore.API.EndPoints;
using BooksStore.API.Data;
using BooksStore.API.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddControllers();

builder.Services.AddTransient<ITimeService, TimeGetter>();

builder.AddBookStoreDb();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MigrateDb();
    app.MapAll();
    app.UseMiddleware<ShowParametrs>();
}

app.Use(async (context, next) =>
{
    await next.Invoke(context);

    ITimeService? getter = app.Services.GetService<ITimeService>();

    if (getter is not null)
    {
        await context.Response.WriteAsync(getter.GetTime());
    }
});

app.Run();