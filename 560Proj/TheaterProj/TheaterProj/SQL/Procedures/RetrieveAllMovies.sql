CREATE OR ALTER PROCEDURE RetrieveAllMovies AS

SELECT M.MovieName, M.ReleaseYear, M.Runtime, M.AverageUserScore, GT.GenreType
FROM Movies.Movie M
	INNER JOIN Movies.MovieGenre MG ON M.MovieID = MG.MovieID
	INNER JOIN Movies.GenreType GT ON MG.GenreTypeID = GT.GenreTypeID
	INNER JOIN Movies.ContentRating CR ON M.MovieID = CR.MovieID
