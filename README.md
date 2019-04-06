# auto

1. dotnet run
2. dotnet build
3. dotnet watch run
4. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
5. dotnet ef migrations add InitialModel
6. dotnet ef database update


GET https://localhost:5001/api/vehicles
GET https://localhost:5001/api/vehicles?page=2

bugs:
1. Edit vahicle and set new features. api request failed.
2. errors from server do not poup up in angular app

todo
1. rename public static class IQueryableExtensions to QueryableExtensions
2. add styles to pagination control
