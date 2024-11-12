IF OBJECT_ID(N'Theaters.ShowTime') IS NULL
BEGIN
CREATE TABLE [Theaters].[ShowTime]
(
	[ScreenID] INT NOT NULL IDENTITY(1,1), 
    MovieID INT NOT NULL,
	[DateTime] DATE NOT NULL,

	PRIMARY KEY(ScreenID, MovieID),
	FOREIGN KEY(ScreenID) REFERENCES Theaters.Screen(ScreenID),
	FOREIGN KEY(MovieID) REFERENCES Movies.Movie(MovieID)
)
END;