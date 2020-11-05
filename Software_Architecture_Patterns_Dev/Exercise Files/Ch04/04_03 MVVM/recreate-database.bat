if exist .\Database\mvvm-database.db (
    del .\Database\mvvm-database.db
)

if not exist .\Database (
    mkdir .\Database
)

sqlite3 .\Database\mvvm-database.db < recreate-database.sql & pause
