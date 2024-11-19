CREATE OR ALTER PROCEDURE Theaters.AddShowTime 
	@ScreenID INT,
	@DateTime DATETIME,
	@MovieID INT
AS

INSERT Theaters.ShowTime(ScreenID, [DateTime], MovieID)
VALUES(@ScreenID, @DateTime, @MovieID)

