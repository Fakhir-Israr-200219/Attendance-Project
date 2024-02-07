create database  AttendancePro

use AttendancePro

create table Students(
	Student_Id int identity(1,1) primary key,
	FirstName NVARCHAR(50), 
	LastName NVARCHAR(50),
	Phone NVARCHAR(50)
)

create table Attendance(
	Attendance int identity(1,1) primary key,
	Student_Id int foreign key References Students(Student_Id),
	AttendanceDate Date,
	Status nvarchar(50)
)

INSERT INTO Students(FirstName,LastName,Phone) 
VALUES ('Taimoor','Khan','03212458'),
('Raja','Akmal','03212458'),
('Chota','Bheem','03212458')


Insert INTO Attendance(Student_Id,AttendanceDate,Status)
Values (1,'2024-02-12','Present'),
(2,'2024-02-12','Present'),
(3,'2024-02-12','Absent')

Select * From Students
Select * From Attendance