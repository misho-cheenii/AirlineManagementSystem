use AirlineManagement_V2;

create table administration(
	username varchar(32) NOT NULL PRIMARY KEY,
    password VARCHAR(64) NOT NULL
);

create table manager(
	id int IDENTITY(1,1) PRIMARY KEY,
    phone_no tinyint NOT NULL,
    f_Name VARCHAR(32) NOT NULL,
    l_Name VARCHAR(32) NOT NULL,
    address	VARCHAR(2048) NOT NULL,
    email	VARCHAR(64) NOT NULL UNIQUE,
    salary	int	not null,
    password VARCHAR(64) NOT NULL,
    username VARCHAR(64) NOT NULL UNIQUE
);

CREATE TABLE passenger(
	id int IDENTITY(1,1) PRIMARY KEY,
    phone_no tinyint NOT NULL,
    f_Name VARCHAR(32) NOT NULL,
    l_Name VARCHAR(32) NOT NULL,
    address	VARCHAR(2048) NOT NULL,
    email	VARCHAR(64) NOT NULL UNIQUE,
    password VARCHAR(64) NOT NULL,
    username VARCHAR(64) NOT NULL UNIQUE
);

create table airplane(
	id varchar(8) primary key,
	name VARCHAR(32) NOT NULL unique
);

create table classprice(
	id int IDENTITY(1,1) Primary key,
    class VARCHAR(32) NOT NULL,
    capacity int	not null,
	price int	not null,
	a_id varchar(8) foreign key(a_id) references airplane(id)
);

create table location(
	id int IDENTITY(1,1) PRIMARY KEY,
	name	varchar(64) not null unique 
);

CREATE TABLE flight(
	id Varchar(8) PRIMARY KEY,
    source int foreign key(Source) references location(id),
    destination int foreign key(destination) references location(id),
    Departure	datetime NOT NULL,
    Arrival DATEtime NOT NULL,
    air_id varchar(8) foreign key(air_id) references airplane(id)
);

create table booking(
	id int IDENTITY(1,1) PRIMARY KEY,
	luggage decimal(2) NOT NULL,
    constraint Weight check (luggage <= 40),
    p_id int FOREIGN KEY REFERENCES passenger(id),
    f_id Varchar(8) FOREIGN KEY REFERENCES flight(id),
	class_id int FOREIGN KEY REFERENCES classprice(id)
);

CREATE TABLE ticket(
	id int IDENTITY(1,1) PRIMARY KEY,
    b_id int FOREIGN KEY REFERENCES booking(id)
);