if exist .\ExploreCalifornia.CQRSES\ExploreCalifornia.CQRSES\AppData\CQRSES-database.db (
    del .\ExploreCalifornia.CQRSES\ExploreCalifornia.CQRSES\AppData\CQRSES-database.db
)

if not exist .\ExploreCalifornia.CQRSES\ExploreCalifornia.CQRSES\AppData (
    mkdir .\ExploreCalifornia.CQRSES\ExploreCalifornia.CQRSES\AppData
)

sqlite3 .\ExploreCalifornia.CQRSES\ExploreCalifornia.CQRSES\AppData\CQRSES-database.db < recreate-database.sql & pause
