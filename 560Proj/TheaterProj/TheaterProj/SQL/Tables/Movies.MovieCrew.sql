IF OBJECT_ID(N'Movies.MovieCrew') IS NULL
BEGIN
CREATE TABLE Movies.MovieCrew
(
	CrewMemberID INT NOT NULL,
	MovieID INT NOT NULL,
	

	PRIMARY KEY(CrewMemberID),
	FOREIGN KEY(MovieID) REFERENCES Movies.Movie(MovieID),

)
END;