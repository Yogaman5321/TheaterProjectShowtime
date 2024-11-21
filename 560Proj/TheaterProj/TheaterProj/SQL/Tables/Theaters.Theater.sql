IF OBJECT_ID(N'Theaters.Theater') IS NULL
BEGIN
CREATE TABLE [Theaters].[Theater]
	(
		TheaterID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		LocationID INT NOT NULL,
		TheaterChainID INT NOT NULL,
		TheaterName NVARCHAR(50),

		FOREIGN KEY(LocationID) REFERENCES Theaters.[Location](LocationID),
		FOREIGN KEY(TheaterChainID) REFERENCES Theaters.TheaterChain(TheaterChainID)
	
	)
END;

