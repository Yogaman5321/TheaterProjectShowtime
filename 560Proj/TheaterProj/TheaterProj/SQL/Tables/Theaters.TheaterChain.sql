﻿IF OBJECT_ID(N'Theaters.TheaterChain') IS NULL
BEGIN
CREATE TABLE [Theaters].[TheaterChain]
(
	TheaterChainID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TheaterChainName NVARCHAR(20) NOT NULL UNIQUE
)
END;