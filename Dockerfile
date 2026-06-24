# pobiera gotowy obraz SDK .NET 10.0 z Microsoft Container Registry
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# tworzenie katalogu roboczego w kontenerze
WORKDIR /src

# kopiowanie pliku projektu do katalogu roboczego w kontenerze
COPY ["automationexerciseAPI.csproj", "./"]

# przywracanie zależności projektu
RUN dotnet restore "automationexerciseAPI.csproj"

# Kopiowanie kodu źródłowego
COPY . .

# KLUCZOWA ZMIANA: Uruchomienie testów przy starcie kontenera
ENTRYPOINT ["dotnet", "test", "automationexerciseAPI.csproj", "--logger:trx", "--results-directory", "/src/TestResults"]

