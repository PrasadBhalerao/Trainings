if exist .\ExploreCalifornia.ToursService\ExploreCalifornia.ToursService\AppData\soa-tours-database.db (
    del .\ExploreCalifornia.ToursService\ExploreCalifornia.ToursService\AppData\soa-tours-database.db
)

if not exist .\ExploreCalifornia.ToursService\ExploreCalifornia.ToursService\AppData (
    mkdir .\ExploreCalifornia.ToursService\ExploreCalifornia.ToursService\AppData
)

sqlite3 .\ExploreCalifornia.ToursService\ExploreCalifornia.ToursService\AppData\soa-tours-database.db < recreate-tour-database.sql



if exist .\ExploreCalifornia.BookingsService\ExploreCalifornia.BookingsService\AppData\soa-bookings-database.db (
    del .\ExploreCalifornia.BookingsService\ExploreCalifornia.BookingsService\AppData\soa-bookings-database.db
)

if not exist .\ExploreCalifornia.BookingsService\ExploreCalifornia.BookingsService\AppData (
    mkdir .\ExploreCalifornia.BookingsService\ExploreCalifornia.BookingsService\AppData
)

sqlite3 .\ExploreCalifornia.BookingsService\ExploreCalifornia.BookingsService\AppData\soa-bookings-database.db < recreate-bookings-database.sql & pause
