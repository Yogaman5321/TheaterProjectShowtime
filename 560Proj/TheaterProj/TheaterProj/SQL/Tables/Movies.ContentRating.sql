
IF OBJECT_ID(N'Movies.ContentRating') IS NULL
BEGIN
	CREATE TABLE Movies.ContentRating
	(
		ContentRatingID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		MovieID INT NOT NULL,
		ContentRating NVARCHAR(10) NOT NULL,

		FOREIGN KEY(MovieID) REFERENCES Movies.Movie(MovieID)
	)
END;