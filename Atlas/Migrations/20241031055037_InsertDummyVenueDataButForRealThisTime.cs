using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atlas.Migrations
{

    public partial class InsertDummyVenueDataButForRealThisTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                schema: "Venue",
                table: "Venues",
                columns: new []{"VenueId", "VenueGuid", "VenueName"},
                values: new object[,]
                {
                    { 2, Guid.NewGuid(), "Soldiers and Sailors Memorial Auditorium" },
                    { 3, Guid.NewGuid(), "The Walker Theatre" },
                    { 4, Guid.NewGuid(), "The Tivoli Theatre" },
                }
            );



        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
                schema: "Venue",
                table: "Venues",
                keyColumn: "VenueName",
                keyValues: new object[] { "Soldiers and Sailors Memorial Auditorium",  "The Walker Theatre", "The Tivoli Theatre"}
            );


        }
    }
}
