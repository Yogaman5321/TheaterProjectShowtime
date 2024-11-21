CREATE OR ALTER PROCEDURE GetCrewMembersForMovie
	@MovieName NVARCHAR(50)
AS
SELECT CM.PersonType, CM.FirstName, CM.LastName
FROM Movies.Movie M
	INNER JOIN Movies.MovieCrew MC ON M.MovieID = MC.MovieID
	INNER JOIN Movies.CrewMember CM ON MC.CrewMemberID = CM.CrewMemberID
WHERE M.MovieName = @MovieName
GO
