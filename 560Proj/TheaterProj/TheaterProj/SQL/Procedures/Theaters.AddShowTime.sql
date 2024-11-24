CREATE OR ALTER PROCEDURE Theaters.AddShowTime 
    @ScreenID INT,
    @DateTime DATETIME,
    @MovieID INT
AS

MERGE Theaters.ShowTime T
USING (SELECT @ScreenID AS ScreenID, @DateTime AS [DateTime], @MovieID AS MovieID) AS S
        ON T.ScreenID = S.ScreenID AND T.[DateTime] = S.[DateTime]
WHEN MATCHED AND T.MovieID != S.MovieID THEN
    UPDATE
    SET T.MovieID = S.MovieID
WHEN NOT MATCHED THEN
    INSERT(ScreenID, [DateTime], MovieID)
    VALUES(@ScreenID, @DateTime, @MovieID);
GO