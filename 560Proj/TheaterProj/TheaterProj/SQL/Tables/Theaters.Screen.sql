
IF OBJECT_ID(N'Theaters.Screen') IS NULL
BEGIN
CREATE TABLE [Theaters].[Screen]
(
	[ScreenID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	ScreenTypeID TINYINT NOT NULL, 
	TheaterID INT NOT NULL,
	ScreenNumber INT NOT NULL, 

	FOREIGN KEY(ScreenTypeID) REFERENCES Theaters.ScreenType(ScreenTypeID),
	FOREIGN KEY(TheaterID) REFERENCES Theaters.Theater(TheaterID)
    
)
END;