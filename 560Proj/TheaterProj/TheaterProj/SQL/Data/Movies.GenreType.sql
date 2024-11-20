DECLARE @GenreTypeStaging TABLE
(
	GenreTypeID TINYINT NOT NULL PRIMARY KEY,
	GenreType NVARCHAR(14) NOT NULL UNIQUE

);

INSERT @GenreTypeStaging(GenreTypeID, GenreType)
VALUES
	(1, 'Drama'),
	(2, 'Crime'),
	(3, 'Action'),
	(4, 'Adventure'),
	(5, 'Biography'),
	(6, 'History'),
	(7, 'Thriller'),
	(8, 'Mystery'),
	(9, 'Romance'),
	(10, 'DocuDrama'),
	(11, 'Western'),
	(12, 'Fantasy'),
	(13, 'Superhero'),
	(14, 'War'),
	(15, 'Horror'),
	(16, 'Music'),
	(17, 'SciFi'),
	(18, 'Comedy'),
	(19, 'Animation'),
	(20, 'Family'),
	(21, 'FilmNoir'),
	(22, 'Tragedy');

MERGE Movies.GenreType GT
USING @GenreTypeStaging S ON S.GenreTypeID = GT.GenreTypeID
WHEN MATCHED AND S.GenreType <> GT.GenreType THEN
	UPDATE
	SET GenreType = S.GenreType
WHEN NOT MATCHED THEN
	INSERT(GenreTypeID, GenreType)
	VALUES(S.GenreTypeID, GenreType);