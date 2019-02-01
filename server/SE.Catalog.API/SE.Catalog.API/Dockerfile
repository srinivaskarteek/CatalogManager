#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["SE.Catalog.API/SE.Catalog.API.csproj", "SE.Catalog.API/"]
RUN dotnet restore "SE.Catalog.API/SE.Catalog.API.csproj"
COPY . .
WORKDIR "/src/SE.Catalog.API"
RUN dotnet build "SE.Catalog.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SE.Catalog.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SE.Catalog.API.dll"]