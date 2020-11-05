rmdir /s /q .\ExploreCalifornia.Processor\ExploreCalifornia.Processor\bin
dotnet build ./ExploreCalifornia.Processor & ^
dotnet build ./ExploreCalifornia.BookingsServicePlugin & ^
dotnet build ./LandonHotel.BookingsServicePlugin & ^
pause
