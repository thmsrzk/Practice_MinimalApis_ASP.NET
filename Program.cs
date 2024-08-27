using Microsoft.AspNetCore.Mvc;
using MinimalApis;

var builder = WebApplication.CreateBuilder();

var list = new List<Article>
{
    new Article(1, "Marteau"),
    new Article(2, "Scie")
};

var app = builder.Build();

app.MapGet("/get", () => "Hello GET!");
app.MapDelete("/delete", () => "Hello DELETE!");
app.MapPost("/post", () => "Hello POST!");
app.MapPut("/put", () => "Hello PUT!");
app.MapPatch("/patch", () => "Hello PATCH!");

app.MapMethods("/methods", new[] { "GET", "POST" }, () => "Hello methods!");

app.MapGet("/article", () => new Article(1, "Marteau"));

app.MapGet("/articles/{id}", (int id) =>
{
    var article = list.Find(a => a.Id == id);
    if (article != null) return Results.Ok(article);

    return Results.NotFound();
});

app.MapGet("/personne/{nom}", (
    [FromRoute] string nom,
    [FromQuery] string? prenom,
    [FromHeader(Name = "Accept-Encoding")] string encoding) => Results.Ok($"{nom} {prenom}"));

//app.MapGet("/personne/identite", (Personne p) => Results.Ok(p));
app.MapPost("/personne/identite", (Personne p) => Results.Ok(p));

app.Run();