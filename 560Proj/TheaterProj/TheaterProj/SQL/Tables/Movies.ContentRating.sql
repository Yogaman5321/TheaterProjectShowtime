IF OBJECT_ID(N'Movies.ContentRating') IS NULL
BEGIN
	CREATE TABLE Movies.ContentRating
	(
		ContentRatingID TINYINT NOT NULL PRIMARY KEY,
		ContentRating NVARCHAR(10) NOT NULL UNIQUE	
	);
END;