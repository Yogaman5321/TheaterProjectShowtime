IF OBJECT_ID(N'Movies.ContentRating') IS NULL
BEGIN
	CREATE TABLE Movies.ContentRating
	(
		ContentRatingID TINYINT NOT NULL PRIMARY KEY,
		MovieID INT NOT NULL,
		ContentRating NVARCHAR(10) NOT NULL UNIQUE,

		FOREIGN KEY(MovieID) REFERENCES Movies.Movie(MovieID)
	);
END;