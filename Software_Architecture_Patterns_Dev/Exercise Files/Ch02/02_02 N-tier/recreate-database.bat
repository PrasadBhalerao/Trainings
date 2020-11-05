if exist .\ExploreCalifornia.DataTier\ntier-database.db (
    del .\ExploreCalifornia.DataTier\ntier-database.db
)

if not exist .\ExploreCalifornia.DataTier (
    mkdir .\ExploreCalifornia.DataTier
)

sqlite3 .\ExploreCalifornia.DataTier\ntier-database.db < recreate-database.sql & pause
