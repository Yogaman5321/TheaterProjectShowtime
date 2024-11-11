IF OBJECT_ID(N'Theaters.Screen') IS NULL
BEGIN
CREATE TABLE [Theaters].[Screen]
(
	[ScreenID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	ScreenType INT NOT NULL, --Idk if this should be an int or not. I just know that enums are technically integers.
	TheaterID INT NOT NULL,
	ScreenNumber INT NOT NULL, --Need to ask a question.

	FOREIGN KEY(TheaterID) REFERENCES Theaters.Theater(TheaterID)
    
)
END;