revoke all on database users_db from public;
revoke all on schema public from public;

grant connect on database users_db to db_user;
grant usage on schema public to db_user;
grant select on all sequences in schema public to db_user;
grant select on all tables in schema public to db_user;

alter default privileges in schema public grant select, update, insert, delete on tables to db_user;
alter default privileges in schema public grant select, update on sequences to db_user;

grant select, update on all sequences in schema public to db_user;
grant select, update, insert, delete on all tables in schema public to db_user;