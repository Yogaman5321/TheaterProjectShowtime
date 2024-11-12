
--THIS IS NOT FINISHED YET!!!!!!!!!

DECLARE @PersonTypeStaging TABLE
(
	PersonTypeID TINYINT NOT NULL PRIMARY KEY,
	PersonType NVARCHAR(10) NOT NULL UNIQUE

);

INSERT @PersonTypeStaging(PersonTypeID, PersonType)
VALUES
	(1, 'Actor'),
	(2, 'Actress'),
	(3, 'Director'),
	(4, 'Writer');
	

MERGE tempDB.Movies.Movie M
USING @ContentRatingStaging S ON S.ContentRatingID = M.ContentRatingID
WHEN MATCHED AND S.ContentRating <> M.ContentRating THEN
	UPDATE
	SET ContentRating = S.ContentRating
WHEN NOT MATCHED THEN
	INSERT(ContentRatingID, ContentRating)
	VALUES(S.ContentRatingID, S.ContentRating);