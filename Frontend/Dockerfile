# Etap 1: Budowanie aplikacji
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiowanie plików projektów i przywracanie zależności
COPY ["Frontend/Frontend.csproj", "Frontend/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Frontend/Frontend.csproj"

# Kopiowanie reszty plików i budowanie aplikacji
COPY . .
WORKDIR "/src/Frontend"
RUN dotnet publish "Frontend.csproj" -c Release -o /app/publish

# Etap 2: Tworzenie obrazu serwera WWW
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .

# Expose port 80
EXPOSE 80

# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]
