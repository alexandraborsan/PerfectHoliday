using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectHoliday.Migrations
{
    public partial class Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStars = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HotelID",
                table: "Booking",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Hotel_HotelID",
                table: "Booking",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Hotel_HotelID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Booking_HotelID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Booking");
        }
    }
}
