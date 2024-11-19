CREATE OR ALTER PROCEDURE Movies.GetMoviesByRating 
	@Rating TINYINT
AS

Select *
FROM Movies.Movie M
WHERE M.ContentRatingID =  @Rating
GO