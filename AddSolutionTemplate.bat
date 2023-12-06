@echo off
IF [%~1]==[] goto invalidParams

dotnet new sln --name Day%1
dotnet new console -n Aoc2023Day%1 -o src/Aoc2023Day%1
dotnet new xunit -n Aoc2023Day%1Test -o test/Aoc2023Day%1Test

dotnet sln Day%1.sln add src/Aoc2023Day%1
dotnet sln Day%1.sln add test/Aoc2023Day%1Test

dotnet sln Aoc2023.sln add src/Aoc2023Day%1
dotnet sln Aoc2023.sln add test/Aoc2023Day%1Test

GOTO end

:invalidParams
echo Usage AddSolutionTemplate ^<DayNumber^>

:end