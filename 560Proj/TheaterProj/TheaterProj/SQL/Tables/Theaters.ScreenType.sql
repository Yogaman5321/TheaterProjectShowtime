﻿
IF OBJECT_ID(N'Theaters.ScreenType') IS NULL
BEGIN
	CREATE TABLE Theaters.ScreenType
	(
		ScreenTypeID TINYINT NOT NULL PRIMARY KEY,
		ScreenType NVARCHAR(10) NOT NULL UNIQUE	
	)
END;