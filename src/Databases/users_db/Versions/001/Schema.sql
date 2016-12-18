CREATE SEQUENCE seq_user_id;

CREATE TABLE "user" (
    id BIGINT PRIMARY KEY DEFAULT NEXTVAL('seq_user_id'), 
    public_id uuid not null,
    email varchar(256) not null
);

CREATE TABLE user_info (
    user_id BIGINT PRIMARY KEY REFERENCES "user" (id), 
    first_name varchar(30) not null, 
    last_name varchar(30) not null, 
    address varchar(100) not null
);

CREATE TABLE membership (
    user_id BIGINT PRIMARY KEY REFERENCES "user" (id),
    password varchar(256) not null,
    password_salt varchar(256) not null
);
