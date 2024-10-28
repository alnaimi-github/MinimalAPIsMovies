using MinimalAPIsMovies.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/genre", () =>
{
    List<Genre> genres =
    [
        new() { Id = 1, Name = "Drama" },
        new() { Id = 2, Name = "Drama" },
        new() { Id = 3, Name = "Drama" }
    ];
    return genres;
});

app.Run();

