create table Person (
	PersonId int not null identity(1,1) primary key,
	Name varchar(100) not null,
	Age int not null,
	PhotoURL varchar(300),
	IsTaken bit
)