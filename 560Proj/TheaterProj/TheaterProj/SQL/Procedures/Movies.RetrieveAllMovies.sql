CREATE OR ALTER PROCEDURE Movies.RetrieveAllMovies AS

SELECT M.MovieName, M.ReleaseYear, M.Runtime, M.AverageUserScore
FROM Movies.Movie M
	INNER JOIN Movies.MovieGenre MG ON M.MovieID = MG.MovieID
