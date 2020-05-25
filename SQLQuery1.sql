use MyTrello;

--create table Users (
--	UserId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	User_FirstName varchar(50) NOT NULL,
--	User_LastName varchar(50) NOT NULL,
--	User_PhotoPath varchar(150) NOT NULL,
--	User_Email varchar(100) NOT NULL,
--	User_Password varchar(20) NOT NULL
--);

--create table Tasks (
--	TaskId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	Task_Priority varchar(20) NOT NULL,
--	Task_Name varchar(70) NOT NULL,
--	Task_CreateDate date NOT NULL,
--	Task_Description varchar(200),
--	UserId int FOREIGN KEY REFERENCES Users(UserId)
--);

select * from Users
select * from Tasks

insert into dbo.Users(User_FirstName, User_LastName, User_PhotoPath, User_Email, User_Password)
values
	('Natali', 'Enot', '/test.jpg', 'test@gmail.com', 'natashanatasha')

insert into dbo.Tasks(Task_Priority, Task_Name, Task_CreateDate, Task_Description, UserId)
values
	('red', 'Programming', '20200424', 'learn react and redux', 1)