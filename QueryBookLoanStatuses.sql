SELECT Books.Title AS Title, BorrowedBooks.Due
FROM
	BorrowedBooks
	INNER JOIN AspNetUsers ON BorrowedBooks.Account=AspNetUsers.Id
	RIGHT JOIN Books ON BorrowedBooks.BookId=Books.BookId
	WHERE AspNetUsers.Email = 'test@test.com'