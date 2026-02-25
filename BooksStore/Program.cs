using BooksStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapAll();

app.Run();
