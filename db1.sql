Create Table Customer(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(50),
LastName varchar(50),
Zipcode int,
Email varchar(50),
PhoneNo varchar(50),
DOB date,
)

--alter table customer and add column time datatype date time
insert into Customer VALUES('Bot','Last',123456,'bot@bot','+9141412','12-1-2000')
select *from Customer
Create Table AdminLogin(
username varchar(50),
Password varchar(50),
)
select*from AdminLogin
insert into AdminLogin(username,Password) VALUES('admin','admin')

Create Table cred(
url varchar(max),
usr varchar(max),
ip varchar(max),
)
select *from cred
