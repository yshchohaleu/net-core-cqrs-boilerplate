SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.datname IN ('users_db') 
  AND pid <> pg_backend_pid();

DROP DATABASE IF EXISTS users_db;
DROP ROLE IF EXISTS db_user; 

create user db_user with password 'O4FbZVgZoKlUjd4Y3faS';
