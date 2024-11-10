﻿IF OBJECT_ID(N'Movies.CrewMember') IS NULL
BEGIN
CREATE TABLE [Movies].[CrewMember]
(
	[CrewMemberID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    MovieID INT NOT NULL,
	PersonType INT NOT NULL,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,

	FOREIGN KEY(MovieID) REFERENCES Movies.Movie(MovieID)
)
END;