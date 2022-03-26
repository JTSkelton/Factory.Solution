# **Factory**

#### _a C# MVC Factory_

#### by **Jack Skelton**

#### March 26, 2022

## Technologies Used

- C#
- .NET 5.0
- REPL
- MySQL
- Razor
- ASP.NET Core

## Description

A website where a factory owner can manage equiptment and employees

## Project Setup/Installation Instructions

### Install C#, .NET, MySQL Community Server and MySQL Workbench

- Open the terminal on your local machine
- If [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) and [.NET](https://docs.microsoft.com/en-us/dotnet/) are not installed on your local device, follow the instructions here [here](https://www.learnhowtoprogram.com/c-and-net-part-time/getting-started-with-c/installing-c-and-net).
- If [MySQL Community Server](https://dev.mysql.com/downloads/mysql/) and [MySQL Workbench](https://www.mysql.com/products/workbench/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time/getting-started-with-c/installing-and-configuring-mysql).

### Clone the project

- Open the terminal on your local computer.
- Navigate to the parent directory of your preference.
- Clone this project using `$ git clone https://github.com/JTSkelton/Factory.Solution.git`
- Navigate to the directory: `$ cd Factory.Solution`
- Open in Vs code: `$ code .`
- Navigate to Factory: `$ cd Factory` and type the following command in the terminal `$ dotnet restore`
- Run the program in the console with the command `$ dotnet run`

### Import and connect the database

- Launch the MySQL server with the command `mysql -uroot -p[YOUR-PASSWORD-HERE]`
- After the server starts running, open MySQL Workbench.
- Navigate to the Factory.Solution folder and create a file called `appsettings.json`
- Navigate to the appsettings.json file `$ cd appsettings.json` and paste:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=jack_skelton;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
}
```

- In appsettings.json, edit the [YOUR-PASSWORD-HERE] with your MySQL password
- In your terminal be sure to update your SQL database by entering the command `dotnet ef database update`
  -This command should push the database migration to your SQL workbench
- After you are finished with the above steps, reopen the **Navigator > Schemas** tab. Right click and select **Refresh All**. Your new test database will appear.
- Navigate to Factory: `$ cd Factory` and type the following command in the terminal `$ touch appsettings.json`

### Run the project

- Navigate to Factory: `$ cd Factory` and type the following command in the terminal `$ dotnet restore`
- Run the program in the console with the command `$ dotnet run`

## Known Bugs

- _None._

## License

[MIT License](https://opensource.org/licenses/MIT) © 2022 Jack Skelton

## Contact

Jack Skelton: [skelton.jt9@gmail.com](mailto:skelton.jt9@gmail.com)
