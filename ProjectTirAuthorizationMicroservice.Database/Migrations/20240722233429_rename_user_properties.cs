using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTirAuthorizationMicroservice.Database.Migrations
{
    /// <inheritdoc />
    public partial class rename_user_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "UserPatronymic",
                table: "Users",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserBirtdayDate",
                table: "Users",
                newName: "BirthdayDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "UserSurname");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Users",
                newName: "UserPatronymic");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "BirthdayDate",
                table: "Users",
                newName: "UserBirtdayDate");
        }
    }
}
