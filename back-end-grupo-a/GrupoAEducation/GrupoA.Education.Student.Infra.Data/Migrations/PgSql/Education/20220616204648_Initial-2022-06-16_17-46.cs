using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoA.Education.Student.Infra.Data.Migrations.PgSql.Education
{
    public partial class Initial20220616_1746 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_Itin_Mail_Name_Ra",
                table: "Student",
                columns: new[] { "Itin", "Mail", "Name", "Ra" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student_Itin_Mail_Name_Ra",
                table: "Student");
        }
    }
}
