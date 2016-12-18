#!/bin/bash

echo Start creating users_db from scratch:

echo Create users_db
sudo -u postgres -H -- psql -f ./CreateDatabase.sql

echo Updates for version 001
sudo -u postgres -H -- psql -d sms_users_db -a -f ./Versions/001/Permissions.sql
sudo -u postgres -H -- psql -d sms_users_db -a -f ./Versions/001/Schema.sql
sudo -u postgres -H -- psql -d sms_users_db -a -f ./Versions/001/Data.sql

echo End creating users_db from scratch