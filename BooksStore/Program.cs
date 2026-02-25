using BooksStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<BookDto> books =
[
    new BookDto(1, "History the Zynres"),
    new BookDto(2, "Created in Abyss"),
];

// GET all books
app.MapGet("/books", () => books);

// GET book by index
app.MapGet("/books/{id}", (int id) => books.Find(books => books.Id == id));

app.Run();
