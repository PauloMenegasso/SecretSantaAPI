Create Table SantaFriend (
	SantaFriendId int not null identity(1,1) primary key,
	santaId int not null,
	friendId int not null
)