CREATE TABLE Accounts (
	Email nvarchar(50) NOT NULL,
	AccountPassword nvarchar(max) NOT NULL,

	PRIMARY KEY(Email),
)
/*
CREATE TABLE Books (
	BookId int IDENTITY NOT NULL,
	ISBN nvarchar(max) NOT NULL,
	Title nvarchar(max) NOT NULL,
	Author nvarchar(max) NOT NULL,

	PRIMARY KEY(BookId),
)
*/
CREATE TABLE BorrowedBooks (
	Account nvarchar(50) NOT NULL,
	BookId int NOT NULL,
	Borrowed Date NOT NULL,
	Due Date NOT NULL,

	PRIMARY KEY(Account, BookId),
	FOREIGN KEY(Account) REFERENCES Accounts(Email),
	FOREIGN KEY(BookId) REFERENCES Books(BookId),
)



