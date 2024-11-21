
$Server = "(localdb)\ProjectModels"
$Database = "master"

Get-Module -ListAvailable -Name SqlServer;
Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Scripts\DropTables.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Scripts\InvokeDrop.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Schema\Theaters.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Schema\Movies.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.ScreenType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.TheaterChain.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.GenreType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.Movie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.ContentRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.MovieCrew.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.MovieGenre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.Location.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.Theater.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Movies.CrewMember.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.Screen.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Tables\Theaters.ShowTime.sql"

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\Theaters.ScreenType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillTheaterChain.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\Movies.GenreType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillRatings.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillMovieCrew.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillMovieGenre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillLocations.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillTheaters.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillCrewMembers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillScreens.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Data\FillShowTimes.sql"

Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Procedures\GetCrewMembersForMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Procedures\RetrieveAllMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Procedures\RetrieveFullTheater.sql"

#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\TheaterProj\SQL\Procedures\Theaters.AddShowTime.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive