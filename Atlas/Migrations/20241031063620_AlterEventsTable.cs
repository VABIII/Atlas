using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atlas.Migrations
{
    /// <inheritdoc />
    public partial class AlterEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventImgSrc",
                schema: "Event",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventLink",
                schema: "Event",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventTime",
                schema: "Event",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.RenameColumn(
                schema: "Event",
                table: "Events",
                newName: "EventArtist",
                name: "EventName"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventImgSrc",
                schema: "Event",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventLink",
                schema: "Event",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTime",
                schema: "Event",
                table: "Events");
        }
    }
}
