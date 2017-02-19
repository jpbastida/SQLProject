CREATE DATABASE Library;

CREATE TABLE Books
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Title NVARCHAR(100) NOT NULL,
Author NVARCHAR(100) NOT NULL,
Genre NVARCHAR(50) NOT NULL,
Year INT NOT NULL
)
GO

CREATE TABLE Students
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(200) NOT NULL
);

CREATE TABLE BorrowedBooks
(
Id INT IDENTITY(1,1) PRIMARY KEY,
BookId INT,
StudentId INT,
IsBorrowed  BIT,
FOREIGN KEY(BookId) REFERENCES Books(Id),
FOREIGN KEY(StudentId) REFERENCES Students(Id)
);

INSERT INTO Books( Title, Author, Genre, Year)
VALUES 
('Title1','Author1','Physics',2001),
('Title2','Author2','Math',2011),
('Title3','Author3','Phisics',2007),
('Title4','Author4','VLSI',2016),
('Title5','Author5','Electronics',2005),
('Title6','Author6','History',2003),
('Title7','Author7','Economics',1979),
('Title8','Author8','Aeronautics',1985),
('Title9','Author9','Languages',2017),
('Title10','Author10','Physics',2001);


INSERT INTO Students (Name)
	VALUES (N'Lupe'),
			(N'Antonio'),
			(N'Jesus'),
			(N'Carolina'),
			(N'Pedro'),
			(N'Felipe'),
			(N'Maria'),
			(N'Yana'),
			(N'Josefina'),
			(N'Daniel'),
			(N'Carmen'),
			(N'Jose');

INSERT INTO BorrowedBooks (BookId, StudentId, IsBorrowed)
	VALUES	(5, 8, 1),
			(2, 3, 1),
			(5, 9, 1),
			(7, 1, 1),
			(9, 7, 1),
			(1, 3, 1),
			(5, 9, 0),
			(4, 5, 1),
			(6, 3, 0),
			(6, 3, 1),
			(2, 3, 0),
			(10, 11, 1),
			(3, 11, 1);