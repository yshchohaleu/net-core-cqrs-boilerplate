
set PGPASSWORD=%2
@echo off
echo Start creating users_db from scratch:

echo Create users
psql -U postgres -h %1 -f CreateUsers.sql

cd users_db
@call create_from_scratch.bat %1
cd ..