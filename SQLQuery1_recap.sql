create database southwind
CREATE TABLE Cars (
    Id int,
    BrandId int,
    ColorId int,
    ModelYear int,
    DailyPrice int,
    Name varchar(255)
);
CREATE TABLE Brands (
    Id int,
    Name varchar(255)
);
CREATE TABLE Colors (
    Id int,
    Name varchar(255)
);