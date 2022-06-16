echo "dotnet ef migrations add Initial-$(date +%Y-%m-%d_%H-%M) --output-dir Migrations/PgSql/Education --project GrupoA.Education.Student.Infra.Data --context EducationDbContext"

echo "dotnet ef database update --project GrupoA.Education.Student.Infra.Data --context EducationDbContext"
