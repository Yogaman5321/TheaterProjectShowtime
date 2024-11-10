IF NOT EXISTS
	(
		SELECT *
		FROM sys.schemas s
		WHERE s.[Name] = N'Theaters'
	)
	BEGIN
		EXEC(N'CREATE SCHEMA [Theaters] AUTHORIZATION [dbo]');
	END;