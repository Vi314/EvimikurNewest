using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class YearlyVacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkYears",
                table: "EmployeeYearlyVacations",
                newName: "Year");

            migrationBuilder.AlterColumn<int>(
                name: "YearlyVacationDays",
                table: "EmployeeYearlyVacations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VacationDaysUsed",
                table: "EmployeeYearlyVacations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "EmployeeYearlyVacations",
                newName: "WorkYears");

            migrationBuilder.AlterColumn<int>(
                name: "YearlyVacationDays",
                table: "EmployeeYearlyVacations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VacationDaysUsed",
                table: "EmployeeYearlyVacations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
