# State and National Parks API

### Created by William Mentzer

## Links

* [Repository](https://github.com/WiiliamMentzer/ParksApi)

## Description
  A Web API which allows for full creation, reading, updating, and deletion of a Database storing States and Parks. A state can have many parks but a park can only have one state.


## Features
  Full CRUD and ui available via swagger.

## Technologies Used

* Built in VS Code (v.1.70.1) using the following languages:
	* C#
	* .NET
	* MSTest
  * HTML
  * MySQL
  * Entity
  * Razor

## Installation

* Download [Git Bash](https://git-scm.com/downloads)
* Input the following into Git Bash to clone this repository onto your computer:

		>git clone https://github.com/WiiliamMentzer/ParksApi

* Enter the root directory of the cloned repository.

* Make sure a .gitignore is included.

* Once completed then type:

	* $ dotnet restore
  * $ dotnet build

* Create a file named "appsettins.json"

  After so you can put the following code into the json.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[NAME OF DATABASE];uid=root;pwd=[YOUR PASSWORD];"
  }
}
```
* Create the seeded database with the command in the terminal
  ```dotnet ef migrations add Initial```

* Update the database with the command in the terminal
  ```dotnet ef database update```

* After such you can type:

	```$ dotnet run```

* You can access the API via http://localhost:5000 or use Swagger to modify the database in Real-Time via WebUI.


## Swagger Documentation

You can enter swagger via https://localhost:5000/swagger in your browser once the API is running.

This will allow full CRUD in real time and display all information via UI.

* CRUD options
  * Parks
    * GET (Read)| `/api/Parks` : Allows the user to look at all parks and query via park name.
    * POST (Create)| `/api/Parks` : Allows the user to add a new park to the database (Required binding stateId).
    * GET (Read)| `/api/Parks/{id}` : Allows the user to look up a specific park via parkId (Ex. /api/parks/3).
    * PUT (Update)| `/api/Parks/{id}` : Allows the user to update parks in the database provided you have the ID for the park.
    * DELETE (Delete)| `/api/Parks/{id}` : Allows the user to delete a park in the database provided you have the ID for the park.
  <br>
  * States
    * GET (Read)| `/api/States` : Allows the user to look at all states and query via state name.
    * POST (Create)| `/api/States` : Allows the user to add a new state to the database.
    * GET (Read)| `/api/States/{id}` : Allows the user to look up a specific state via stateId (Ex. /api/states/3).
    * PUT (Update)| `/api/States/{id}` : Allows the user to update states in the database provided you have the ID for the state.
    * DELETE (Delete)| `/api/States/{id}` : Allows the user to delete a state in the database provided you have the ID for the state.

* Available Querys
  * Parks: Name via `/api/Parks?name="NAME HERE"`
  * States: Title and Population via, `/api/States?title="TITLE HERE" for title` and `/api/States?population="POPULATION"`

## How to use the Swagger Interface

  * GET
    * For either States or Parks, you can select the GET tab and it should open a new UI
    * One of these buttons shouls say "Try it out", Click that.
    * A user interface will be able to query the paramaters you wish to search via, or run "Execute" to run the command with no paramaters.
    * A new value will appear being "Responses" this will show the output of the response whether the value was a success or a failure and return a status code. This should display all information of the category you selected OR the specific ID you have targeted.
  * POST
    * For either States or Parks, you can select the POST tab and it should open a new UI
    * One of these buttons shouls say "Try it out", Click that.
    * A user interface will appear in which you can add information to the POST request. Run "Execute" to run the command (Note parks will REQUIRE a stateID).
    * A new value will appear being "Responses" this will show the output of the console whether the balue was a success or a failure and return a status code.
  * PUT
    * For either States or Parks, you can select the PUT tab and it should open a new UI
    * One of these buttons shouls say "Try it out", Click that.
    * A user interface will be able to select the item you wish to modify via ID. "Execute" to run the command (Note Parks will REQUIRE a stateId).
    * A new value will appear being "Responses" this will show the output of the console whether the value change was a success 204 or failure 400.
  * DELETE
    * For either States or Parks, you can select the DELETE tab and it should open a new UI
    * One of these buttons shouls say "Try it out", Click that.
    * A user interface will be able to query the paramaters you wish to delete. Run "Execute" to run the command.
    * Depending on the status code the item with either Delete and return code 200 or return an error 404 in the Responses.

## Known Bugs

* N/A

## License

MIT License

Copyright (c) [2022] [William Mentzer]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Copyright (c) _11/7/2022_ _William Mentzer_