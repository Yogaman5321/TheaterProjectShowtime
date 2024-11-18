DECLARE @GenreTypeStaging TABLE
(
	GenreTypeID TINYINT NOT NULL PRIMARY KEY,
	GenreType NVARCHAR(14) NOT NULL UNIQUE

);

INSERT @GenreTypeStaging(GenreTypeID, GenreType)
VALUES
	(1, 'Action'),
	(2, 'Adventure'),
	(3, 'Animation'),
	(4, 'Biography'),
	(5, 'Comedy'),
	(6, 'Crime'),
	(7, 'Drama'),
	(8, 'Fantasy'),
	(9, 'Family'),
	(10, 'FilmNoir'),
	(11, 'Horror'),
	(12, 'Musical'),
	(13, 'Mystery'),
	(14, 'Romance'),
	(15, 'SciFi'),
	(16, 'Thriller'),
	(17, 'War');

MERGE Movies.GenreType GT
USING @GenreTypeStaging S ON S.GenreTypeID = GT.GenreTypeID
WHEN MATCHED AND S.GenreType <> GT.GenreType THEN
	UPDATE
	SET GenreType = S.GenreType
WHEN NOT MATCHED THEN
	INSERT(GenreTypeID, GenreType)
	VALUES(S.GenreTypeID, GenreType);