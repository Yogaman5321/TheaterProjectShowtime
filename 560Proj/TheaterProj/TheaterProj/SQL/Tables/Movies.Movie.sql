﻿
IF OBJECT_ID(N'Movies.Movie') IS NULL
BEGIN
CREATE TABLE [Movies].[Movie]
(
	[MovieID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	MovieName NVARCHAR(50) NOT NULL UNIQUE,
	ReleaseYear INT NOT NULL,
	Runtime INT NOT NULL,
	AverageUserScore DECIMAL(18,1),
	ContentRatingID TINYINT NOT NULL,

	FOREIGN KEY(ContentRatingID) REFERENCES Movies.ContentRating(ContentRatingID)
)
END;