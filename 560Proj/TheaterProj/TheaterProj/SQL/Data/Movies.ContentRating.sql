DECLARE @ContentRatingStaging TABLE
(
	ContentRatingID TINYINT NOT NULL PRIMARY KEY,
	ContentRating NVARCHAR(10) NOT NULL UNIQUE

);

INSERT @ContentRatingStaging(ContentRatingID, ContentRating)
VALUES
	(1, 'G'),
	(2, 'PG'),
	(3, 'PG13'),
	(4, 'R'),
	(5, 'NC17');

MERGE Movies.ContentRating CR
USING @ContentRatingStaging S ON S.ContentRatingID = CR.ContentRatingID
WHEN MATCHED AND S.ContentRating <> CR.ContentRating THEN
	UPDATE
	SET ContentRating = S.ContentRating
WHEN NOT MATCHED THEN
	INSERT(ContentRatingID, ContentRating)
	VALUES(S.ContentRatingID, S.ContentRating);