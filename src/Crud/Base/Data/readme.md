dotnet ef  migrations add "v-1" -p .\Crud\ -s .\Crud.Api\ -o "Base\Data\Migrations"
dotnet ef database update -p .\Crud\ -s .\Crud.Api\