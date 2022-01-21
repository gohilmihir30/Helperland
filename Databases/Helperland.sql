CREATE DATABASE Helperland;

CREATE TABLE Users (
	user_id int not null primary key AUTO_INCREMENT,
	Email varchar(25) not null unique,
	password varchar(255)not null,
	userType varchar(2) not null check (usertype IN(0,1,2)),
	status varchar(2) not null check (status IN(0,1))
);

CREATE TABLE Customer (

	cust_id int not null primary key foreign key references users(user_id),
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Mobile varchar(10) NOT NULL,
	DOB Date,
	PreferredLanguage varchar(50),
	);


CREATE TABLE Address (
	AddressId int not null primary key AUTO_INCREMENT,
	cust_id int not null foreign key references customer(cust_id),
	StreetName varchar(50) not null,
	HouseNumber varchar(30) not null,
	PostalCode varchar(6) not null,
	City varchar(20) not null,
	Mobile varchar(10) not null,
)

CREATE TABLE ServiceProvider 
(
	sp_id int not null primary key foreign key references users(user_id),
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Mobile varchar(10) not null,
	DOB date ,
	nationality varchar(20) ,
	Gender varchar(15),
	Avtar varchar(30),
	Street_Name varchar(20),
	House_Number varchar(10),
	Postal_code varchar(6) not null,
	City varchar(20),
)

CREATE TABLE Services (
	ServiceId int not null primary key AUTO_INCREMENT,
	cust_id int not null foreign key references customer(cust_id),
	sp_id int not null foreign key references serviceProvider(sp_id),
	AddressId int not null,
	serviceDate date not null,
	TimeDuration float not null,
	serviceTime time not null,
	cabinetService bit not null,
	fridgeService bit not null,
	ovenService bit not null,
	laundyanddryService bit not null,
	interiorWindows bit not null,
	HavePet bit not null,
	payment money not null,
	comments varchar(255),
	onArrivalTimeRating varchar(1) check( onArrivalTimeRating IN(1,2,3,4,5)),
	friendlyRating varchar(1) check( friendlyRating IN(1,2,3,4,5)),
	QOSRating varchar(1) check( QOSRating IN(1,2,3,4,5)),
	Feedback varchar(255),
	Status varchar(1) check (status IN (0,1,2,3,4)),
	RefundAmount money,
	RefundReason varchar(255),
	CancleReason varchar(255),
) 

CREATE TABLE FavouritySP(
	Cust_id int foreign key references customer(cust_id) not null,
	SP_id int foreign key references serviceProvider(sp_id) not null,
)

Create table Blocklist (
	blockerID int not null,
	blockedID int not null,
)