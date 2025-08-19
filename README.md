# ConnectSea Full Solution (SQL Server)

This archive contains a backend configured for SQL Server and a frontend Angular skeleton.

Backend:
- Uses Microsoft.EntityFrameworkCore.SqlServer
- Default connection string: LocalDB (Server=(localdb)\mssqllocaldb)

To run backend:
- cd backend/ConnectSea.Api
- dotnet restore
- dotnet tool install --global dotnet-ef
- dotnet ef migrations add Initial
- dotnet ef database update
- dotnet run

Frontend:
- cd frontend/connectsea-ui
- npm install
- npm start
