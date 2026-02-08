using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Powers.Migrations
{
    /// <inheritdoc />
    public partial class FixRatingYearNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieRating",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEdited",
                table: "Applications",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieRating",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEdited",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
