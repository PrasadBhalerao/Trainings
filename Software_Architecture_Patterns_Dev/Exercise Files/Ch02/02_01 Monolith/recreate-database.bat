if exist .\ExploreCalifornia.Monolith\ExploreCalifornia.Monolith\AppData\monolith-database.db (
    del .\ExploreCalifornia.Monolith\ExploreCalifornia.Monolith\AppData\monolith-database.db
)

if not exist .\ExploreCalifornia.Monolith\ExploreCalifornia.Monolith\AppData (
    mkdir .\ExploreCalifornia.Monolith\ExploreCalifornia.Monolith\AppData
)

sqlite3 .\ExploreCalifornia.Monolith\ExploreCalifornia.Monolith\AppData\monolith-database.db < recreate-database.sql & pause
