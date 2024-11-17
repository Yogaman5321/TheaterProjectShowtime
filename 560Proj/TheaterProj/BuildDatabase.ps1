Param(
   [string] $Server = "(localdb)\ProjectModels",
   [string] $Database = "master"
)

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Scripts\DropTables.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Schema\Theaters.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Schema\Movies.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Movies.ContentRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Movies.CrewMember.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Movies.GenreType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Movies.Movie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Movies.PersonType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.Location.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.Screen.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.ScreenType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.ShowTime.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.Theater.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Tables\Theaters.TheaterChain.sql"

Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Movies.GetAllCrewMembers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Movies.GetAllMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Movies.GetMoviesByGenre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Movies.GetMoviesByName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Movies.GetMoviesByRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.AddShowTime.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.GetAllLocations.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.GetAllScreens.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.GetAllShowTimes.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.GetAllTheaterChains.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Procedures\Theaters.GetAllTheaters.sql"

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Data\Movies.ContentRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Data\Movies.GenreType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Data\Movies.PersonType.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "C:\Users\hunte\source\repos\TheaterProjectShowtime\560Proj\TheaterProj\SQL\Data\Theaters.ScreenType.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive