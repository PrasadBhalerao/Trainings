if exist .\ExploreCalifornia.EventSourcing\ExploreCalifornia.EventSourcing\AppData\EventSourcing-database.db (
    del .\ExploreCalifornia.EventSourcing\ExploreCalifornia.EventSourcing\AppData\EventSourcing-database.db
)

if not exist .\ExploreCalifornia.EventSourcing\ExploreCalifornia.EventSourcing\AppData (
    mkdir .\ExploreCalifornia.EventSourcing\ExploreCalifornia.EventSourcing\AppData
)

sqlite3 .\ExploreCalifornia.EventSourcing\ExploreCalifornia.EventSourcing\AppData\EventSourcing-database.db < recreate-database.sql & pause
