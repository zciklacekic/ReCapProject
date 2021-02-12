--create table Users (Id int,FirstName varchar,LastName varchar,Email varchar, Password varchar);
--create table Customers (Id int,UserId int,CompanyName varchar);
--create table Rentals (Id int,CarId int,CustomerId int,RentDate datetime,ReturnData datetime);
ALTER TABLE Rentals
ALTER COLUMN RentDate datetime2;
--ALTER TABLE Colors
--ADD PRIMARY KEY (Id);
--ALTER TABLE Customers
--ADD FOREIGN KEY (UserId) REFERENCES Users(Id);
--EXEC sp_rename 'Rentals.ReturnData', 'ReturnDate', 'COLUMN';