CREATE OR ALTER PROCEDURE Movies.GetMoviesByGenre 
	@Genre TINYINT
AS

Select *
FROM Movies.Movie M
WHERE M.GenreTypeID =  @Genre
GO