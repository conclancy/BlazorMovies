using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovies.Server.Migrations
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO AspNetRoles (Id, [Name], NormalizedName)
                VALUES ('b4d328bc-0941-44a0-9e5f-90a39acc1c03', 'Admin', 'Admin');"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
