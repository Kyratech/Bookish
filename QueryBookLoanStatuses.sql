SELECT ISNULL(AspNetUsers.Email, 'Available') AS Email, BorrowedBooks.Due
FROM
	BorrowedBooks
	INNER JOIN AspNetUsers ON BorrowedBooks.Account=AspNetUsers.Id
	RIGHT JOIN Books ON BorrowedBooks.BookId=Books.BookId
	WHERE Books.ISBN = '50'