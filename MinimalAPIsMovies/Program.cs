using MinimalAPIsMovies.Entities;
using MinimalAPIsMovies.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenresRepository, GenresRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/genre/GetAll", async (IGenresRepository genresRepository) =>
{
    var result = await genresRepository.GetGenresAsync();
    return Results.Ok(result);

});

app.MapGet("/genre/GetById/{id:int}", async (IGenresRepository genresRepository, int id) =>
{
    var result = await genresRepository.GetAsync(id);
    return Results.Ok(result);

});

app.MapPost("/genre", async (Genre genre, IGenresRepository genresRepository) =>
{
  var result=  await genresRepository.CreateAsync(genre);

  return  Results.Created($"/Get/{result}", genre);
});


app.Run();

