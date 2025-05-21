using System.ComponentModel.DataAnnotations;
namespace GameStore.api.Dtos;

//Add C# Data Annotations to our DTO (Data Transfer Objects).
//This will not work out of the box as 'Minimal APIs' needs to be activated, 'Core MVC framework' does work
public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);


//Code was:
//namespace GameStore.api.Dtos;

/*public record class UpdateGameDto(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);*/