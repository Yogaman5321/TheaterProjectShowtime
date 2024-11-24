CREATE OR ALTER PROCEDURE Theaters.RemoveShowTime 
    @ScreenID INT,
    @DateTime DATETIME
AS

DELETE FROM Theaters.ShowTime
WHERE ScreenID = @ScreenID 
    AND [DateTime] = @DateTime;
GO