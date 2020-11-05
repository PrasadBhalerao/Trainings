@echo off
echo COMMAND MODEL
sqlite3 -column -header .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-write-database.db < show-write-bookings.sql

echo.

echo QUERY MODEL
sqlite3 -column -header .\ExploreCalifornia.Website\ExploreCalifornia.Website\AppData\cqrs-read-database.db < show-read-bookings.sql

echo.

pause
