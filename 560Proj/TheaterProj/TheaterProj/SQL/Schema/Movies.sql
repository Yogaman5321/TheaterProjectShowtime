IF NOT EXISTS
	(
		SELECT *
		FROM sys.schemas s
		WHERE s.[Name] = N'Movies'
	)
	BEGIN
		EXEC(N'CREATE SCHEMA [Movies] AUTHORIZATION [dbo]');
	END;