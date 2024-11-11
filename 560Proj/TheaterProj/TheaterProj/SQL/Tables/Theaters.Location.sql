﻿IF OBJECT_ID(N'Theaters.Location') IS NULL
BEGIN
CREATE TABLE [Theaters].[Location]
(
	[LocationID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [State] NVARCHAR(13) NOT NULL UNIQUE, 
    [Location] NVARCHAR(40) NOT NULL UNIQUE, 
    [City] NVARCHAR(30) NOT NULL
)
END;