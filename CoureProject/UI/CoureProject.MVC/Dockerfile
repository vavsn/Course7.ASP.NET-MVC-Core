#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UI/CoureProject.MVC/CoureProject.MVC.csproj", "UI/CoureProject.MVC/"]
COPY ["Services/CoureProject.WebAPI.Clients/CoureProject.WebAPI.Clients.csproj", "Services/CoureProject.WebAPI.Clients/"]
COPY ["Services/CoureProject.Interfaces/CoureProject.Interfaces.csproj", "Services/CoureProject.Interfaces/"]
COPY ["Services/CoureProject.Interfaces.Base/CoureProject.Interfaces.Base.csproj", "Services/CoureProject.Interfaces.Base/"]
COPY ["Common/CoureProject.Domain/CoureProject.Domain.csproj", "Common/CoureProject.Domain/"]
COPY ["Common/CoureProject.Domain.Base/CoureProject.Domain.Base.csproj", "Common/CoureProject.Domain.Base/"]
RUN dotnet restore "UI/CoureProject.MVC/CoureProject.MVC.csproj"
COPY . .
WORKDIR "/src/UI/CoureProject.MVC"
RUN dotnet build "CoureProject.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoureProject.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoureProject.MVC.dll"]