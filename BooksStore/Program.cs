using BooksStore.API.Data;
using BooksStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddControllers();

builder.AddBookStoreDb();

var app = builder.Build();

app.MigrateDb();

app.MapControllers();
app.MapAll();

app.Run();
