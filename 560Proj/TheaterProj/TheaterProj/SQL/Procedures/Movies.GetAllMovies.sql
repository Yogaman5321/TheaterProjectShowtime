CREATE OR ALTER PROCEDURE Movies.GetAllMovies AS

Select M.MovieName, M.ReleaseYear, M.Runtime, M.AverageUserScore, M.GenreTypeID, M.ContentRatingID
FROM Movies.Movie M
	INNER JOIN Theaters.ShowTime ST ON M.MovieID = ST.MovieID
WHERE ST.[DateTime] >= GETDATE()
GO