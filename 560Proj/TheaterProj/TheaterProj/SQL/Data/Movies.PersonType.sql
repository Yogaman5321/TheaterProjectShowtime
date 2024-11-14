
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
	

MERGE Movies.Movie M
USING @PersonTypeStaging S ON S.PersonTypeID = M.PersonTypeID
WHEN MATCHED AND S.PersonType <> M.PersonType THEN
	UPDATE
	SET PersonType = S.PersonType
WHEN NOT MATCHED THEN
	INSERT(PersonTypeID, PersonType)
	VALUES(S.PersonTypeID, S.PersonType);