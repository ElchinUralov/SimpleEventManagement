
-----------------------------------------------
create procedure InsertUser
@name varchar(50),
@role int
as
begin
	insert into Users(name, role) 
	values
	(@name, @role);
end

create procedure SelectAllUsers
as
begin
	select * from Users;
end

create procedure SelectUserById
@id_user int
as
begin
	select * from Users where id_user = @id_user;
end

---------------------------------------------------------
create procedure SelectAllCompanies
as
begin
	select * from Companies;
end

create procedure SelectCompanyById
@id_company int
as
begin
	select * from Companies where id_company = @id_company;
end

create procedure InsertCompany
@name varchar(50)
as
begin
	insert into Companies(name) 
	values
	(@name);
end
---------------------------------------------------------------
create procedure InsertRoom
@status bit,
@number_of_places int
as
begin
	insert into Rooms(status, number_of_places)
	values
	(@status, @number_of_places);
end

create procedure SelectRoomById
@id_room int
as
begin
	select * from Rooms where id_room = @id_room;
end

create procedure SelectAllRooms
as
begin
	select * from Rooms ;
end
----------------------------------------------------
create procedure InsertOrder
@topic text,
@room int
as
begin
	insert into Orders(topic, room)
	values
	(@topic, @room);
end

create procedure SelectOrderById
@id_order int
as
begin
	select * from Orders where id_order = @id_order;
end

create procedure SelectAllOrders
as
begin
	select * from Orders ;
end
------------------------------------------------------
create procedure InsertCompanyToOrder
@id_company int,
@id_order int,
@status bit,
@start_time datetime,
@end_time datetime,
@number_of_spaces int
as
begin
	insert into CompanyToOrders(id_company, id_order, status, start_time, end_time, number_of_spaces)
	values
	(@id_company, @id_order, @status, @start_time, @end_time, @number_of_spaces);
end

create procedure SelectCompanyToOrderById
@id_company_to_order int
as
begin
	select * from CompanyToOrders where id_company_to_order = @id_company_to_order;
end

create procedure SelectAllCompanyToOrder
as
begin
	select * from CompanyToOrders ;
end
------------------------------------------------------
create procedure SelectAllEvent
as
begin
	select * from Events;
end

create procedure InsertEvent
@id_company_to_order int,
@id_room int,
@status bit
as
begin
	insert into Events(id_company_to_order, id_room, status)
	values
	(@id_company_to_order, @id_room, @status);
end

create procedure SelectEventById
@id_event int
as
begin
	select * from Events where id_event = @id_event;
end
------------------------------------------------------

