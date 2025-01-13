using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rezerwacje_lotnicze.Migrations
{
    /// <inheritdoc />
    public partial class CorrectFlightMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseFlightBaseTicket");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "BaseFlightBaseTicket",
                columns: table => new
                {
                    BaseTicketId = table.Column<int>(type: "integer", nullable: false),
                    FlightsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFlightBaseTicket", x => new { x.BaseTicketId, x.FlightsId });
                    table.ForeignKey(
                        name: "FK_BaseFlightBaseTicket_Flights_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseFlightBaseTicket_Tickets_BaseTicketId",
                        column: x => x.BaseTicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFlightBaseTicket_FlightsId",
                table: "BaseFlightBaseTicket",
                column: "FlightsId");
        }
    }
}
