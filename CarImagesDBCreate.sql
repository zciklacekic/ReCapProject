CREATE TABLE CarImages (
    Id int,
    CarId int,
    ImagePath varchar(255),
    Date DateTime
);

ALTER TABLE CarImages
ALTER COLUMN Id int NOT NULL;

ALTER TABLE CarImages
ADD PRIMARY KEY (Id);
ALTER TABLE CarImages
ADD FOREIGN KEY (CarId) REFERENCES Cars(Id);