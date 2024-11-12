DECLARE @ScreenTypeStaging TABLE
(
	ScreenTypeID TINYINT NOT NULL PRIMARY KEY,
	ScreenType NVARCHAR(10) NOT NULL UNIQUE

);

INSERT @ScreenTypeStaging(ScreenTypeID, ScreenType)
VALUES
	(1, 'IMAX'),
	(2, 'Dolby');


MERGE Theaters.ScreenType ST
USING @ScreenTypeStaging S ON S.ScreenTypeID = ST.ScreenTypeID
WHEN MATCHED AND S.ScreenType <> ST.ScreenType THEN
	UPDATE
	SET ScreenType = S.ScreenType
WHEN NOT MATCHED THEN
	INSERT(ScreenTypeID, ScreenType)
	VALUES(S.ScreenTypeID, S.ScreenType);