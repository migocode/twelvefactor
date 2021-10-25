#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV TF_DbConnectionString=mongodb://localhost:27017 TF_DbNAme=PersonDb
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TwelveFactor.WebApi/TwelveFactor.WebApi.csproj", "TwelveFactor.WebApi/"]
RUN dotnet restore "TwelveFactor.WebApi/TwelveFactor.WebApi.csproj"
COPY . .
WORKDIR "/src/TwelveFactor.WebApi"
RUN dotnet build "TwelveFactor.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwelveFactor.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwelveFactor.WebApi.dll"]