@echo off
echo Start creating users_db from scratch:

echo Create users_db
psql -U postgres -h %1  -f CreateDatabase.sql

echo Updates for version 001 
psql -U postgres -h %1  -d users_db -f Versions/001/Permissions.sql
psql -U postgres -h %1  -d users_db -f Versions/001/Schema.sql
psql -U postgres -h %1  -d users_db -f Versions/001/Data.sql

echo End creating users_db from scratch