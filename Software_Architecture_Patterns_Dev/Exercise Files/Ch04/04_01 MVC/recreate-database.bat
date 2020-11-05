if exist .\ExploreCalifornia.MVC\ExploreCalifornia.MVC\AppData\mvc-database.db (
    del .\ExploreCalifornia.MVC\ExploreCalifornia.Monolith\MVC\mvc-database.db
)

if not exist .\ExploreCalifornia.MVC\ExploreCalifornia.MVC\AppData (
    mkdir .\ExploreCalifornia.MVC\ExploreCalifornia.MVC\AppData
)

sqlite3 .\ExploreCalifornia.MVC\ExploreCalifornia.MVC\AppData\mvc-database.db < recreate-database.sql & pause
