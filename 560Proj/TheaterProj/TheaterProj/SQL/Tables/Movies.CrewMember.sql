IF OBJECT_ID(N'Movies.CrewMember') IS NULL
BEGIN
CREATE TABLE [Movies].[CrewMember]
(
	[CrewMemberID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	PersonType NVARCHAR(15) NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,

	UNIQUE(CrewMemberID, FirstName, LastName),
	FOREIGN KEY (CrewMemberID) REFERENCES Movies.MovieCrew(CrewMemberID)

)
END;

