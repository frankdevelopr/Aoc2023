@echo off
IF [%~1]==[] goto invalidParams

dotnet new sln --name Day%1
dotnet new console -n Aoc2023Day%1 -o src/Aoc2023Day%1
dotnet new xunit -n Aoc2023Day%1Test -o test/Aoc2023Day%1Test

dotnet sln Day%1.sln add src/Aoc2023Day%1
dotnet sln Day%1.sln add test/Aoc2023Day%1Test

dotnet sln Aoc2023.sln add src/Aoc2023Day%1
dotnet sln Aoc2023.sln add test/Aoc2023Day%1Test

copy template\empty.txt src\Aoc2023Day%1\day%1.txt
copy template\evaluation.txt src\Aoc2023Day%1\

mkdir test\Aoc2023Day%1Test\data\ 
copy template\empty.txt test\Aoc2023Day%1Test\data\problem.txt
copy template\empty.txt test\Aoc2023Day%1Test\data\test.txt

GOTO end

:invalidParams
echo Usage AddSolutionTemplate ^<DayNumber^>

:end