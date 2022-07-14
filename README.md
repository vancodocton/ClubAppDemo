# ClubApp
* Using Clean Architecture. The brief introduction is here: https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture
* Nullable reference types is a breaking new came from .NET 6. Applying it to design entity model (aka Model in MVC) for mapping to database may raise some problems such as Warning CS8618. Reading the following for best practices:
  * https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew#scaffold-c-nullable-reference-types
  * https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
# Notes
* Using inti setter for building immutable data. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init
