dotnet test --collect:"XPlat Code Coverage" --no-build
reportgenerator -targetdir:"coveragereport" -reporttypes:"Html" -reports:".\TestResults\*\coverage.cobertura.xml"
.\coveragereport\index.html