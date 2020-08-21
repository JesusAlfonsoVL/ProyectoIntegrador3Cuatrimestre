Create database JAlfonsoExampleCRUD
------------------------------------
Use JAlfonsoExampleCRUD;
------------------------------------
Create table Users(
Id int primary key identity (1,1),
Name nvarchar(50) null,
Address nvarchar(50) null,
Phone nvarchar(50) null,
Email nvarchar(50) null,
UserName nvarchar(50) null,
Password nvarchar(50) null
)
-------------------------------------
Select * from Users;
--insert into Users value ('','','','','','');
Select @@Identity;
delete from Users where Id != 1;
delete from Users where Id = 20;