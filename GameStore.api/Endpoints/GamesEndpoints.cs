
//namespace GameStore.Api.GamesEndpoints;
namespace GameStore.Api.Endpoints;
using GameStore.api.Dtos;
/*
* Step #01 - Copy contents over from Program.cs, this is 1:20:22 Using extension methods
* Step #02 - 1:25:46 Using route groups
             “Group Builder” will allow use to not hard code strings like "games"
             Not having the same name all over the place is know as Route Group Builder.
*/

public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";

    //private static readonly List<GameDto> games = [];

    private static readonly List<GameDto> games = [
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

    //public static WebApplication MapGameEndpoints(this WebApplication app)
    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        //var group = app.MapGroup("games");
        var group = app.MapGroup("games")
        .WithParameterValidation();
        
        //Get /games (All Games)
        //app.MapGet("games", () => games);
        //group.MapGet("games", () => games);
        group.MapGet("/", () => games);

        //Get /Games/1 (That is get game with specificed ID)
        //app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
        //.WithName(GetGameEndpointName);

        //Get /Games/1 (That is get game with specificed ID)
        //app.MapGet("games/{id}", (int id) =>
        //group.MapGet("games/{id}", (int id) =>
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        //POST /games (Create a new entry)
        //app.MapPost("games", (CreateGameDto newGame) =>
        //group.MapPost("games", (CreateGameDto newGame) =>
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });
        //.WithParameterValidation();

        //Put Games (At next index) (Does not prevent duplicates)
        //app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
        //group.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
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
        });

        // DELETE /Games/1 (At index specfied)
        //app.MapDelete("games/{id}", (int id) =>
        //group.MapDelete("games/{id}", (int id) =>
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        //return app;
        return group;
    }
}
