#!/bin/bash

echo Start creating users_db from scratch:

echo Create users
sudo -u postgres -H -- psql -f ./CreateUsers.sql

cd users_db
sh ./create_from_scratch.sh $1
cd ..
