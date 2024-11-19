IF OBJECT_ID(N'Movies.MovieGenre') IS NULL
BEGIN
CREATE TABLE Movies.MovieGenre
(
	MovieID INT NOT NULL,
	GenreTypeID TINYINT NOT NULL

	PRIMARY KEY(MovieID, GenreTypeID),
	FOREIGN KEY (MovieID) REFERENCES Movies.Movie(MovieID),
	FOREIGN KEY (GenreTypeID) REFERENCES Movies.GenreType

)
END;