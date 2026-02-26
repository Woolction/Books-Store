using BooksStore.API.Data;
using BooksStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.AddBookStoreDb();

var app = builder.Build();

app.MigrateDb();
app.MapAll();

app.Run();
