using GameStore.api.Dtos;
using GameStore.Api.Endpoints;
//using GameStore.Api.Endpoints.GamesEndpoints; //UFH8N Added

/*
 * https://www.youtube.com/watch?v=AhAxLiGC7Pc
 * Julio Casal      https://www.youtube.com/@juliocasal
 * ASP.NET Core Full Course For Beginners
 * 22/02/2024 | 3:43:17
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGameEndpoints();


//const string GetGameEndpointName = "GetGame"; //Moved GamesEndpoints

//Moved GamesEndpoints
/*
List<GameDto> games = [ 
    new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)),
    new (
        2,
        "Final Fantasy XIV",
        "Roleplaying",
        59.99M,
        new DateOnly(2010, 9, 30)),
     new (
        3,
        "FIFA 23",
        "Sports",
        69.99M,
        new DateOnly(2022, 9, 27))
];
*/

//Moved all  the following to GamesEndpoints 

//Get /games (All Games)
//app.MapGet("games", () => games);

//Get /Games/1 (That is get game with specificed ID)
//app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
//.WithName(GetGameEndpointName);

//Get /Games/1 (That is get game with specificed ID)
/*
app.MapGet("games/{id}", (int id) => 
{
    GameDto? game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);*/

//POST /games (Create a new entry)
/*
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});
*/

//Put Games (At next index) (Does not prevent duplicates)
/*
app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if(index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );

    return Results.NoContent();
});*/

// DELETE /Games/1 (At index specfied)
/*
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});*/

//app.MapGet("/", () => "Hello World!! - This is [ASP.NET Core Full Course For Beginners] by [Julio Casal] at [3:43:17] - Luke is Great!");

app.Run();
