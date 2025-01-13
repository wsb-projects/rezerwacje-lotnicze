using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rezerwacje_lotnicze.Migrations
{
    /// <inheritdoc />
    public partial class CorrectTicketMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tickets_BaseTicketId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_BaseTicketId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "BaseTicketId",
                table: "Flights");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseFlightBaseTicket");

            migrationBuilder.AddColumn<int>(
                name: "BaseTicketId",
                table: "Flights",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_BaseTicketId",
                table: "Flights",
                column: "BaseTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Tickets_BaseTicketId",
                table: "Flights",
                column: "BaseTicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
