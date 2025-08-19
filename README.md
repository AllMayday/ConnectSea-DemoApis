# ConnectSea Solução Completa (SQL Server)

Este repositório contém um backend configurado para **SQL Server**.

## Backend
- Usa **Microsoft.EntityFrameworkCore.SqlServer**  
- String de conexão padrão: **LocalDB** (`Server=(localdb)\mssqllocaldb`)  

Como executar:

cd backend/ConnectSea.Api
  dotnet restore
  dotnet tool install --global dotnet-ef
  dotnet ef migrations add Initial
  dotnet ef database update
  dotnet run
