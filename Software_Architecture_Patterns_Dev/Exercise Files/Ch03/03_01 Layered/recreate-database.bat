if exist .\ExploreCalifornia.Layered\ExploreCalifornia.Database\layered-database.db (
    del .\ExploreCalifornia.Layered\ExploreCalifornia.Database\layered-database.db
)

if not exist .\ExploreCalifornia.Layered\ExploreCalifornia.Database (
    mkdir .\ExploreCalifornia.Layered\ExploreCalifornia.Database
)

sqlite3 .\ExploreCalifornia.Layered\ExploreCalifornia.Database\layered-database.db < recreate-database.sql & pause
