$Env:itemsPath=$("$(Get-Location)\Data\items.json")
$Env:itemTypesPath=$("$(Get-Location)\Data\itemtypes.json")

cd GildedRose

dotnet build

dotnet run --no-build set-employee --employeeId 1 --employeeName John --employeeSalary 333

cd ..