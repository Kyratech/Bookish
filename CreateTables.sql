CREATE TABLE Accounts (
	Username nvarchar(30) NOT NULL,
	AccountPassword nvarchar(max) NOT NULL,

	PRIMARY KEY(Username),
)

CREATE TABLE Books (
	BookId int IDENTITY NOT NULL,
	ISBN nvarchar(max) NOT NULL,
	Title nvarchar(max) NOT NULL,
	Author nvarchar(max) NOT NULL,

	PRIMARY KEY(BookId),
)

CREATE TABLE BorrowedBooks (
	Account nvarchar(30) NOT NULL,
	BookId int NOT NULL,
	Borrowed Date NOT NULL,
	Due Date NOT NULL,

	PRIMARY KEY(Account, BookId),
	FOREIGN KEY(Account) REFERENCES Accounts(Username),
	FOREIGN KEY(BookId) REFERENCES Books(BookId),
)



