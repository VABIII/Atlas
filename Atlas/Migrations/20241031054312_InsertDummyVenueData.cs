using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atlas.Migrations
{
    /// <inheritdoc />
    public partial class InsertDummyVenueData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                schema: "Event",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Events_EventId",
                schema: "Event",
                table: "EventArtists");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                schema: "Event",
                table: "EventArtists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                schema: "Event",
                table: "EventArtists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                schema: "Event",
                table: "EventArtists",
                column: "ArtistId",
                principalSchema: "Artist",
                principalTable: "Artists",
                principalColumn: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Events_EventId",
                schema: "Event",
                table: "EventArtists",
                column: "EventId",
                principalSchema: "Event",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                schema: "Event",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Events_EventId",
                schema: "Event",
                table: "EventArtists");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                schema: "Event",
                table: "EventArtists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                schema: "Event",
                table: "EventArtists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                schema: "Event",
                table: "EventArtists",
                column: "ArtistId",
                principalSchema: "Artist",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Events_EventId",
                schema: "Event",
                table: "EventArtists",
                column: "EventId",
                principalSchema: "Event",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
