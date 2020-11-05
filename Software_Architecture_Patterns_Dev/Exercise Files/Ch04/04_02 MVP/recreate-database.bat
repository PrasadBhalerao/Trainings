if exist .\Database\mvp-database.db (
    del .\Database\mvp-database.db
)

if not exist .\Database (
    mkdir .\Database
)

sqlite3 .\Database\mvp-database.db < recreate-database.sql & pause
