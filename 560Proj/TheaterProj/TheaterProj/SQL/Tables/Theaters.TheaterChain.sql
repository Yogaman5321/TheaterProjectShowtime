
IF OBJECT_ID(N'Theaters.TheaterChain') IS NULL
BEGIN
CREATE TABLE [Theaters].[TheaterChain]
(
	TheaterChainID INT NOT NULL PRIMARY KEY,
	TheaterChainName NVARCHAR(20) NOT NULL UNIQUE
)
END;