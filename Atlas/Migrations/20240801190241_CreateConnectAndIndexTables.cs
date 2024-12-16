using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atlas.Migrations
{
    /// <inheritdoc />
    public partial class CreateConnectAndIndexTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Artist");

            migrationBuilder.EnsureSchema(
                name: "Event");

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VenueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Venue",
                        principalTable: "Venues",
                        principalColumn: "VenueId");
                });

            migrationBuilder.CreateTable(
                name: "EventArtists",
                schema: "Event",
                columns: table => new
                {
                    EventArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventArtists", x => x.EventArtistId);
                    table.ForeignKey(
                        name: "FK_EventArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "Artist",
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventArtists_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "Event",
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventArtists_ArtistId",
                schema: "Event",
                table: "EventArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_EventArtists_EventId",
                schema: "Event",
                table: "EventArtists",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                schema: "Event",
                table: "Events",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventArtists",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "Artist");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "Event");
        }
    }
}
