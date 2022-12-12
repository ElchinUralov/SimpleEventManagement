create database Event_Management3;

DROP table IF Exists Rooms;
create table Rooms (
	id_room int identity primary key,
	status bit not null,
	number_of_places int not null)

DROP table IF Exists Users;
create table Users (
	id_user int identity primary key,
	name varchar(50) not null,
	role int not null)

DROP table IF Exists Companies;
create table Companies (
	id_company int identity primary key,
	name varchar(100) not null)

DROP table IF Exists Orders;
create table Orders (
	id_order int identity primary key,
	topic text not null,
	room int)

	DROP table IF Exists CompanyToOrders;
create table CompanyToOrders (
	id_company_to_order int identity primary key,
	id_company int foreign key references Companies(id_company),
	id_order int foreign key references Orders(id_order),
	status bit not null,
	start_time datetime,
	end_time datetime,
	number_of_spaces int)

DROP table IF Exists Events;
create table Events (
	id_event int identity primary key,
	id_company_to_order int foreign key references CompanyToOrders(id_company_to_order),
	id_room int foreign key references Rooms(id_room),
	status bit not null)

DROP table IF Exists UsersToEvents;
create table UsersToEvents (
	id_user_to_event int identity primary key,
	id_user int foreign key references Users(id_user),
	id_event int foreign key references Events(id_event))