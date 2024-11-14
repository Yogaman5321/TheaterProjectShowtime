CREATE OR ALTER PROCEDURE Movies.GetMoviesByName
	@Name NVARCHAR(50)
AS

Select *
FROM Movies.Movie M
WHERE M.MovieName LIKE @Name
GO