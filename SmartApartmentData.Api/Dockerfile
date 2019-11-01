#FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "SmartApartmentData.Api.dll"]

#para build: docker build -t smartapartment .
#para ejecutar con http: docker run -d -p 8181:80 -p 8182:443 --name myapp smartapartment 


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SmartApartmentData.Api/SmartApartmentData.Api.csproj", "SmartApartmentData.Api/"]
RUN dotnet restore "SmartApartmentData.Api/SmartApartmentData.Api.csproj"
COPY . .
WORKDIR "/src/SmartApartmentData.Api"
RUN dotnet build "SmartApartmentData.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartApartmentData.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartApartmentData.Api.dll"]