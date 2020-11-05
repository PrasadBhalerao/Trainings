if exist .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-write-database.db (
    del .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-write-database.db
)

if exist .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-read-database.db (
    del .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-read-database.db
)

if not exist .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData (
    mkdir .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData
)

sqlite3 .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-write-database.db < recreate-write-database.sql
sqlite3 .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-read-database.db < recreate-read-database.sql

pause
