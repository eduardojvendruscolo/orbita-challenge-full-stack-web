using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoA.Education.Student.Infra.Data.Migrations.PgSql.Education
{
    public partial class Initial20220609_1559 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ra = table.Column<int>(type: "integer", nullable: false),
                    Itin = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.PrimaryKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Ra",
                table: "Student",
                column: "Ra",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
