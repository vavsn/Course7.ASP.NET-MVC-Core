#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CoureProject.WebAPI/CoureProject.WebAPI.csproj", "Services/CoureProject.WebAPI/"]
COPY ["Data/CoureProject.DAL/CoureProject.DAL.csproj", "Data/CoureProject.DAL/"]
COPY ["Common/CoureProject.Domain/CoureProject.Domain.csproj", "Common/CoureProject.Domain/"]
COPY ["Common/CoureProject.Domain.Base/CoureProject.Domain.Base.csproj", "Common/CoureProject.Domain.Base/"]
COPY ["Services/CoureProject.Interfaces.Base/CoureProject.Interfaces.Base.csproj", "Services/CoureProject.Interfaces.Base/"]
COPY ["Services/CoureProject.Interfaces/CoureProject.Interfaces.csproj", "Services/CoureProject.Interfaces/"]
COPY ["Data/CoureProject.DAL.MSSQLServer/CoureProject.DAL.SQLiteServer.csproj", "Data/CoureProject.DAL.MSSQLServer/"]
COPY ["Services/CoureProject.Services/CoureProject.Services.csproj", "Services/CoureProject.Services/"]
RUN dotnet restore "Services/CoureProject.WebAPI/CoureProject.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/CoureProject.WebAPI"
RUN dotnet build "CoureProject.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoureProject.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoureProject.WebAPI.dll"]