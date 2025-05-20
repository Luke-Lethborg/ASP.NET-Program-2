# ASP.NET-Program-2
Code from 'Julio Casal' Youtube ending with GC7Pc

** Upload #01 **

** Below is a little wordy for an initial upload **

https://www.youtube.com/watch?v=AhAxLiGC7Pc
ASP.NET Core Full Course For Beginners
Julio Casal
https://www.youtube.com/@juliocasal
22/02/2024
3:43:17
This is code to 1:20:22 of 3:43:17.
The next section we will refactor some code like Program.cs

Purpose of this course is to:
#01	Create ASP.Net Core Apps
#02	Understand REST APIs
#03	Implement CRUD Endpoints
#04	Data Transfer Objects (DTOs)
#05	Extension Methods
#06	Route Groups
#07	Handle Invalid Inputs
#08	Entity Framework Core
#09	Configuration System
#10	Dependency Injection
#11	Service Lifetime
#12	Mapping Entities to DTOs
#13	Asynchronous Programming
#14	Frontend Integration

To use this code:
Open in Visual Studio Code at File Location at 'Program02'
On Terminal
By default your at ....\Program02
CD GameStore.api
Now at ....\Program02\GameStore.api
dotnet run
Open File: games.http
Above each command like: GET http://localhost:5250/games
Select: Send Request

You need Extensions like:
Live Server by Ritwick Dey and REST Client by Huachao Mao

So far we have a basic CRUD happening

"This gets all"
GET http://localhost:5250/games

"This gets id of 1"
GET http://localhost:5250/games/1

"This create a new entry, making it's own ID"
POST http://localhost:5250/games
Content-Type: application/json

{
    "name":        "Minecraft",
    "genre":       "Kids and Family",
    "price":       19.99,
    "releaseDate": "2011-11-18"
}

"This updates an existing entry"
PUT http://localhost:5250/games/1
Content-Type: application/json

{
    "name":        "Street Fighter II Turbo",
    "genre":       "Fighting",
    "price":       9.99,
    "releaseDate": "1991-02-01"
}

"This deletes an existing entry"
DELETE http://localhost:5250/games/4

There is more work to be done, but the first 1:20:22


