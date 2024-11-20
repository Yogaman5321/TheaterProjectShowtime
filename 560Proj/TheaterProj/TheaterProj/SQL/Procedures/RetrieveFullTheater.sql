﻿CREATE OR ALTER PROCEDURE RetrieveAllInfoForTheater 
	@TheaterNumber INT
AS
SELECT T.TheaterName, L.[Address], L.City, L.[State], TC.TheaterChainName, S.ScreenID, S.ScreenNumber, SCT.ScreenType, ST.[DateTime]
FROM Theaters.Theater T
	INNER JOIN Theaters.Screen S ON S.TheaterID = T.TheaterID
	INNER JOIN Theaters.ShowTime ST ON S.ScreenID = ST.ScreenID
	INNER JOIN Theaters.TheaterChain TC ON T.TheaterChainID = TC.TheaterChainID
	INNER JOIN Theaters.ScreenType SCT ON S.ScreenTypeID = SCT.ScreenTypeID
	INNER JOIN Theaters.[Location] L ON L.LocationID = T.LocationID
WHERE T.TheaterID = @TheaterNumber